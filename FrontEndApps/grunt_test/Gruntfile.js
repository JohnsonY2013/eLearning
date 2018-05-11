//包装函数
module.exports = function(grunt) {
    //任务配置，所有插件的配置信息
    grunt.initConfig({
        //获取 package.json的信息
        pkg: grunt.file.readJSON('package.json'),
        //uglify插件的配置信息
        uglify: {
            options: {
                stripBanners: true,
                banner: '/*! <%=pkg.name%>-<%=pkg.version%>.js <%= grunt.template.today("dd-mm-yyyy") %> */\n'
            },
            build: {
                src: 'src/*.js',
                dest: 'build/<%=pkg.name%>-<%=pkg.version%>.min.js'
            }
        },
        //jshint插件的配置信息
        jshint: {
            options: {
                jshintrc: '.jshintrc', //http://www.jianshu.com/p/4cb23f9e19d3
                reporterOutput: ''  //必须项，Path must be a string. Received null Use
            },
            build: ['Gruntfile.js', 'src/*.js']
        },
        //csslint插件的配置信息
        /*        csslint: {
                    options: {
                        csslintrc: '.csslintrc' //http://www.jianshu.com/p/4cb23f9e19d3
                    },
                    build: ['src/*.css']
                },*/
        //watch插件的配置信息
        watch: {
            build: {
                files: ['src/*.js', 'src/*.css'],
                tasks: ['jshint', 'uglify'],
                options: {
                    spawn: false
                }
            }
        }
    });
    // 告诉grunt我们将要使用的插件
    grunt.loadNpmTasks('grunt-contrib-uglify');
    grunt.loadNpmTasks('grunt-contrib-jshint');
    //grunt.loadNpmTasks('grunt-contrib-csslint');
    grunt.loadNpmTasks('grunt-contrib-watch');
    // 当在终端中输入grunt时需要做些什么，注意先后顺序
    grunt.registerTask('default', ['jshint', 'uglify', 'watch']);
};