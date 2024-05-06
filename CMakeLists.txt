cmake_minimum_required(VERSION 3.29.0)
project(LearnOpenGL VERSION 0.1.0 LANGUAGES C CXX)

find_package(OpenGL REQUIRED)

link_directories(${PROJECT_SOURCE_DIR}/lib)

include_directories(include)

#将Common里所有源文件放到一个变量中
file(GLOB_RECURSE COMMON_SRC src/common/*.h, src/common/*.cpp)

#1_1_hello_triangle
add_executable(${PROJECT_NAME}_1_1_hello_triangle src/1_1_hello_triangle/main.cpp)
target_link_libraries(${PROJECT_NAME}_1_1_hello_triangle 
    ${OPENGL_LIBRARIES}
    glad
    glfw3
)

#1_hello_triangle_hw
add_executable(${PROJECT_NAME}_1_1_hello_triangle_hw src/1_1_hello_triangle/main_hw.cpp)
target_link_libraries(${PROJECT_NAME}_1_1_hello_triangle_hw
    ${OPENGL_LIBRARIES}
    glad
    glfw3
)

#1_2_shader
add_executable(${PROJECT_NAME}_1_2_shader
src/1_2_shader/main_hw.cpp
${GLOB_RECURSE}
)
target_link_libraries(${PROJECT_NAME}_1_2_shader
    ${OPENGL_LIBRARIES}
    glad
    glfw3
)

#1_3_texture
add_executable(${PROJECT_NAME}_1_3_texture
${GLOB_RECURSE}
src/1_3_texture/main_hw.cpp
)
target_link_libraries(${PROJECT_NAME}_1_3_texture
    ${OPENGL_LIBRARIES}
    glad
    glfw3
)

#1_4_transform
add_executable(${PROJECT_NAME}_1_4_transform
${GLOB_RECURSE}
src/1_4_transform/main_hw.cpp
)
target_link_libraries(${PROJECT_NAME}_1_4_transform
    ${OPENGL_LIBRARIES}
    glad
    glfw3
)

#1_5_coordinate_systems
add_executable(${PROJECT_NAME}_1_5_coordinate_systems
${GLOB_RECURSE}
src/1_5_coordinate_systems/main_hw.cpp
)
target_link_libraries(${PROJECT_NAME}_1_5_coordinate_systems
    ${OPENGL_LIBRARIES}
    glad
    glfw3
)

#1_6_camera
add_executable(${PROJECT_NAME}_1_6_camera
${GLOB_RECURSE}
src/1_6_camera/main_hw.cpp
)
target_link_libraries(${PROJECT_NAME}_1_6_camera
    ${OPENGL_LIBRARIES}
    glad
    glfw3
)

#2_1_color
add_executable(${PROJECT_NAME}_2_1_color
${GLOB_RECURSE}
src/2_1_color/main_hw.cpp
)
target_link_libraries(${PROJECT_NAME}_2_1_color
    ${OPENGL_LIBRARIES}
    glad
    glfw3
)

#2_2_lighting
add_executable(${PROJECT_NAME}_2_2_lighting
${GLOB_RECURSE}
src/2_2_lighting/main_hw.cpp
)
target_link_libraries(${PROJECT_NAME}_2_2_lighting
    ${OPENGL_LIBRARIES}
    glad
    glfw3
)

#2_3_material
add_executable(${PROJECT_NAME}_2_3_material
${GLOB_RECURSE}
src/2_3_material/main_hw.cpp
)
target_link_libraries(${PROJECT_NAME}_2_3_material
    ${OPENGL_LIBRARIES}
    glad
    glfw3
)

#2_4_lightmap
add_executable(${PROJECT_NAME}_2_4_lightmap
${GLOB_RECURSE}
src/2_4_lightmap/main_hw.cpp
)
target_link_libraries(${PROJECT_NAME}_2_4_lightmap
    ${OPENGL_LIBRARIES}
    glad
    glfw3
)

#2_5_light_casters
add_executable(${PROJECT_NAME}_2_5_light_casters
${GLOB_RECURSE}
src/2_5_light_casters/main_hw.cpp
)
target_link_libraries(${PROJECT_NAME}_2_5_light_casters
    ${OPENGL_LIBRARIES}
    glad
    glfw3
)

#2_6_multi_light
add_executable(${PROJECT_NAME}_2_6_multi_light
${GLOB_RECURSE}
src/2_6_multi_light/main_hw.cpp
)
target_link_libraries(${PROJECT_NAME}_2_6_multi_light
    ${OPENGL_LIBRARIES}
    glad
    glfw3
)

#3_1_model
add_executable(${PROJECT_NAME}_3_1_model
${GLOB_RECURSE}
src/3_1_model/main_hw.cpp
)
target_link_libraries(${PROJECT_NAME}_3_1_model
    ${OPENGL_LIBRARIES}
    glad
    glfw3
    assimp-5
)

#4_1_depth_test
add_executable(${PROJECT_NAME}_4_1_depth_test
${GLOB_RECURSE}
src/4_1_depth_test/main_hw.cpp
)
target_link_libraries(${PROJECT_NAME}_4_1_depth_test
    ${OPENGL_LIBRARIES}
    glad
    glfw3
    assimp-5
)

#4_2_stencil_test
add_executable(${PROJECT_NAME}_4_2_stencil_test
${GLOB_RECURSE}
src/4_2_stencil_test/main_hw.cpp
)
target_link_libraries(${PROJECT_NAME}_4_2_stencil_test
    ${OPENGL_LIBRARIES}
    glad
    glfw3
    assimp-5
)

#4_3_blending
add_executable(${PROJECT_NAME}_4_3_blending
${GLOB_RECURSE}
src/4_3_blending/main_hw.cpp
)
target_link_libraries(${PROJECT_NAME}_4_3_blending
    ${OPENGL_LIBRARIES}
    glad
    glfw3
    assimp-5
)

#4_3_blending
add_executable(${PROJECT_NAME}_4_4_face_culling
${GLOB_RECURSE}
src/4_4_face_culling/main_hw.cpp
)
target_link_libraries(${PROJECT_NAME}_4_4_face_culling
    ${OPENGL_LIBRARIES}
    glad
    glfw3
    assimp-5
)

#4_5_framebuffers
add_executable(${PROJECT_NAME}_4_5_framebuffers
${GLOB_RECURSE}
src/4_5_framebuffers/main_hw.cpp
)
target_link_libraries(${PROJECT_NAME}_4_5_framebuffers
    ${OPENGL_LIBRARIES}
    glad
    glfw3
    assimp-5
)

#4_6_cubemap
add_executable(${PROJECT_NAME}_4_6_cubemap
${GLOB_RECURSE}
src/4_6_cubemap/main_hw.cpp
)
target_link_libraries(${PROJECT_NAME}_4_6_cubemap
    ${OPENGL_LIBRARIES}
    glad
    glfw3
    assimp-5
)

#4_8_uniform_buffer
add_executable(${PROJECT_NAME}_4_8_uniform_buffer
${GLOB_RECURSE}
src/4_8_uniform_buffer/main_hw.cpp
)
target_link_libraries(${PROJECT_NAME}_4_8_uniform_buffer
    ${OPENGL_LIBRARIES}
    glad
    glfw3
    assimp-5
)

#4_9_geometry_shader
add_executable(${PROJECT_NAME}_4_9_geometry_shader
${GLOB_RECURSE}
src/4_9_geometry_shader/main_hw.cpp
)
target_link_libraries(${PROJECT_NAME}_4_9_geometry_shader
    ${OPENGL_LIBRARIES}
    glad
    glfw3
    assimp-5
)

#4_10_instancing
add_executable(${PROJECT_NAME}_4_10_instancing
${GLOB_RECURSE}
src/4_10_instancing/main_hw.cpp
)
target_link_libraries(${PROJECT_NAME}_4_10_instancing
    ${OPENGL_LIBRARIES}
    glad
    glfw3
    assimp-5
)

#4_11_antialiasing
add_executable(${PROJECT_NAME}_4_11_antialiasing
${GLOB_RECURSE}
src/4_11_antialiasing/main_hw.cpp
)
target_link_libraries(${PROJECT_NAME}_4_11_antialiasing
    ${OPENGL_LIBRARIES}
    glad
    glfw3
    assimp-5
)

#5_2_gamma
add_executable(${PROJECT_NAME}_5_2_gamma
${GLOB_RECURSE}
src/5_2_gamma/main_hw.cpp
)
target_link_libraries(${PROJECT_NAME}_5_2_gamma
    ${OPENGL_LIBRARIES}
    glad
    glfw3
    assimp-5
)

#5_3_1_shadow_mapping
add_executable(${PROJECT_NAME}_5_3_1_shadow_mapping
${GLOB_RECURSE}
src/5_3_1_shadow_mapping/main_hw.cpp
)
target_link_libraries(${PROJECT_NAME}_5_3_1_shadow_mapping
    ${OPENGL_LIBRARIES}
    glad
    glfw3
    assimp-5
)

#5_3_2_point_shadow
add_executable(${PROJECT_NAME}_5_3_2_point_shadow
${GLOB_RECURSE}
src/5_3_2_point_shadow/main_hw.cpp
)
target_link_libraries(${PROJECT_NAME}_5_3_2_point_shadow
    ${OPENGL_LIBRARIES}
    glad
    glfw3
    assimp-5
)