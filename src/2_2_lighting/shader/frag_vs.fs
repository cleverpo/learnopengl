#version 330 core

uniform vec3 lightColor;
uniform vec3 objectColor;

in vec3 posVS;
in vec3 normalVS;
in vec3 lightPosVS;

out vec4 FragColor;

void main()
{   
    vec3 normal = normalize(normalVS);
    vec3 lightDir = normalize(lightPosVS - posVS);
    vec3 viewDir = normalize(-posVS);
    vec3 halfDir = normalize(lightDir + viewDir);

    float nDotL = max(dot(normal, lightDir), 0.0f);
    float nDotH = max(dot(normal, halfDir), 0.0f);

    //环境光照
    float ambientStrength = 0.1f;
    vec3 ambient = ambientStrength * lightColor;
    
    //漫反射
    vec3 diffuse = nDotL * lightColor;

    //镜面发射
    float shininess = 32.0f;
    float specularStrength = 0.5f;
    vec3 specular = specularStrength * pow(nDotH, shininess) * lightColor;

    vec3 finalColor = (ambient + diffuse + specular) * objectColor;

    FragColor = vec4(finalColor, 1.0f);
}