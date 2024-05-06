#version 330 core

struct DirectionLight{
    vec3 direction;
    vec3 ambient;
    vec3 diffuse;
    vec3 specular;
};
uniform DirectionLight directionLight;

struct PointLight{
    vec3 position;
    vec3 ambient;
    vec3 diffuse;
    vec3 specular;

    float attenuationFactor1;
    float attenuationFactor2;
    float attenuationFactor3;
};

#define POINT_LIGHTS 4
uniform PointLight pointLights[POINT_LIGHTS];
uniform int pointLightCount;

struct SpotLight{
    vec3 position;
    vec3 direction;
    vec3 ambient;
    vec3 diffuse;
    vec3 specular;
    
    float cutoff;
    float outerCutoff;
    
    float attenuationFactor1;
    float attenuationFactor2;
    float attenuationFactor3;
};
uniform SpotLight spotLight;

uniform sampler2D texture_diffuse1;
uniform sampler2D texture_specular1;

uniform float shininess;

uniform vec3 cameraPos;

in VS_OUT{
    vec3 posWS;
    vec3 normalWS;
    vec2 uv;
}fs_in;

uniform bool isGamma;

out vec4 FragColor;

vec3 calcDirectionLight(DirectionLight light, vec3 normal, vec3 viewDir){
    vec3 lightDir = normalize(-light.direction);
    vec3 halfDir = normalize(lightDir + viewDir);
    vec2 uv = fs_in.uv;
    float nDotL = max(dot(normal, lightDir), 0.0f);
    float nDotH = max(dot(normal, halfDir), 0.0f);
    
    vec3 diffuseColor = texture(texture_diffuse1, uv).rgb;
    vec3 specularColor = texture(texture_specular1, uv).rgb;
    
    //环境光照
    vec3 ambient = light.ambient * diffuseColor;
    
    //漫反射
    vec3 diffuse = light.diffuse * diffuseColor * nDotL;

    //镜面发射
    vec3 specular = light.specular * specularColor * pow(nDotH, shininess);

    return ambient + diffuse + specular;
}

vec3 calcPointLight(PointLight light, vec3 normal, vec3 viewDir, vec3 posWS){
    vec3 lightDir = normalize(light.position - posWS);
    vec3 halfDir = normalize(lightDir + viewDir);
    vec2 uv = fs_in.uv;

    float nDotL = max(dot(normal, lightDir), 0.0f);
    float nDotH = max(dot(normal, halfDir), 0.0f);

    vec3 diffuseColor = texture(texture_diffuse1, uv).rgb;
    vec3 specularColor = texture(texture_specular1, uv).rgb;
    

    //环境光照
    vec3 ambient = light.ambient * diffuseColor;
    
    //漫反射
    vec3 diffuse = light.diffuse * diffuseColor * nDotL;

    //镜面发射
    vec3 specular = light.specular * specularColor * pow(nDotH, shininess);

    //着色点与光源距离
    float distance = length(light.position - posWS);
    float attenuation = 1.0 / (light.attenuationFactor1 + light.attenuationFactor2 * distance + light.attenuationFactor3 * (distance * distance));    //衰减公式

    return (ambient + diffuse + specular) * attenuation;
}

vec3 calcSpotLight(SpotLight light, vec3 normal, vec3 viewDir, vec3 posWS){
    vec3 lightDir = normalize(light.position - posWS);
    vec3 halfDir = normalize(lightDir + viewDir);
    vec2 uv = fs_in.uv;

    float nDotL = max(dot(normal, lightDir), 0.0f);
    float nDotH = max(dot(normal, halfDir), 0.0f);

    vec3 diffuseColor = texture(texture_diffuse1, uv).rgb;
    vec3 specularColor = texture(texture_specular1, uv).rgb;
    

    //环境光照
    vec3 ambient = light.ambient * diffuseColor;
    
    //漫反射
    vec3 diffuse = light.diffuse * diffuseColor * nDotL;

    //镜面发射
    vec3 specular = light.specular * specularColor * pow(nDotH, shininess);

    //用lightDir与light direction的夹角来判断是否在聚光灯内
    float theta = dot(-lightDir, normalize(light.direction));


    //边缘平滑过渡，用内切角与外切角
    float epsilon = light.cutoff - light.outerCutoff;
    //theta小于外切角cos值表示在锥体外面
    float intensity = clamp((theta - light.outerCutoff) / epsilon, 0.0, 1.0);
    
    diffuse *= intensity;
    specular *= intensity;
        
    float distance = length(light.position - posWS);
    float attenuation = 1.0 / (light.attenuationFactor1 + light.attenuationFactor2 * distance + light.attenuationFactor3 * (distance * distance));    //衰减公式
    
    ambient *= attenuation;
    diffuse *= attenuation;
    specular *= attenuation;

    return ambient + diffuse + specular;
}

vec3 gamma(vec3 color){
    float gamma = 2.2;
    return pow(color, vec3(1.0 / gamma));
}

void main()
{   
    vec3 normal = normalize(fs_in.normalWS);
    vec3 viewDir = normalize(cameraPos - fs_in.posWS);

    vec3 finalColor = calcDirectionLight(directionLight, normal, viewDir);

    for(int i = 0; i < pointLightCount; i++){
        finalColor += calcPointLight(pointLights[i], normal, viewDir, fs_in.posWS);
    }
    // finalColor += calcSpotLight(spotLight, normal, viewDir, fs_in.posWS);

    if(isGamma)
        finalColor = gamma(finalColor);

    FragColor = vec4(finalColor, 1.0f);
}