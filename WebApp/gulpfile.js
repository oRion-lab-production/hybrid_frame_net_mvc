/// <binding BeforeBuild='default' ProjectOpened='default' />
const gulp = require('gulp');
const uglify = require('gulp-uglify');
const rename = require('gulp-rename');

const nodeModules = './node_modules';
const libPath = './wwwroot/lib';

gulp.task('default', async function () {

    //font-awesome
    gulp.src(nodeModules + "/font-awesome/css/**/*").pipe(gulp.dest(libPath + "/font-awesome/css/"));
    gulp.src(nodeModules + "/font-awesome/fonts/**/*").pipe(gulp.dest(libPath + "/font-awesome/fonts/"));

    //bootstrap
    gulp.src(nodeModules + "/bootstrap/dist/**/*").pipe(gulp.dest(libPath + "/bootstrap/"));

    //jquery
    gulp.src(nodeModules + "/jquery/dist/**/*").pipe(gulp.dest(libPath + "/jquery/"));

    //jquery-unobtrusive-ajax
    gulp.src(nodeModules + "/jquery-ajax-unobtrusive/dist/**/*").pipe(gulp.dest(libPath + "/jquery-ajax-unobtrusive/"));

    //jquery-validation
    gulp.src(nodeModules + "/jquery-validation/dist/**/*").pipe(gulp.dest(libPath + "/jquery-validation/"));

    //jquery-validation-unobtrusive
    gulp.src(nodeModules + "/jquery-validation-unobtrusive/dist/**/*").pipe(gulp.dest(libPath + "/jquery-validation-unobtrusive/"));

    //popper
    gulp.src(nodeModules + "/popper.js/dist/*").pipe(gulp.dest(libPath + "/popper/"));

    //moment
    gulp.src(nodeModules + "/moment/dist/**/*").pipe(gulp.dest(libPath + "/moment/"));

    //admin-lte
    gulp.src(nodeModules + "/admin-lte/dist/**/*").pipe(gulp.dest(libPath + "/admin-lte/"));

    //overlayscrollbars
    gulp.src([nodeModules + "/overlayscrollbars/js/*.js", nodeModules + "/overlayscrollbars/css/*.css"]).pipe(gulp.dest(libPath + "/overlayscrollbars/"));

    //datatables
    gulp.src([nodeModules + "/datatables.net/js/*.js", nodeModules + "/datatables.net-bs4/js/*.js"]).pipe(gulp.dest(libPath + "/datatables/js/"));
    gulp.src([nodeModules + "/datatables.net-dt/css/*.css", nodeModules + "/datatables.net-bs4/css/*.css"]).pipe(gulp.dest(libPath + "/datatables/css/"));
    gulp.src(nodeModules + "/datatables.net-dt/images/**/*").pipe(gulp.dest(libPath + "/datatables/images/"));
    // autofill
    gulp.src([nodeModules + "/datatables.net-autofill/js/*.js", nodeModules + "/datatables.net-autofill-bs4/js/*.js"]).pipe(gulp.dest(libPath + "/datatables/js/autofill"));
    gulp.src(nodeModules + "/datatables.net-autofill-bs4/css/*.css").pipe(gulp.dest(libPath + "/datatables/css/autofill"));
    // buttons
    gulp.src([nodeModules + "/datatables.net-buttons/js/*.js", nodeModules + "/datatables.net-buttons-bs4/js/*.js"]).pipe(gulp.dest(libPath + "/datatables/js/buttons"));
    gulp.src(nodeModules + "/datatables.net-buttons-bs4/css/*.css").pipe(gulp.dest(libPath + "/datatables/css/buttons"));
    // colreorder
    gulp.src([nodeModules + "/datatables.net-autofill/js/*.js", nodeModules + "/datatables.net-autofill-bs4/js/*.js"]).pipe(gulp.dest(libPath + "/datatables/js/autofill"));
    gulp.src(nodeModules + "/datatables.net-autofill-bs4/css/*.css").pipe(gulp.dest(libPath + "/datatables/css/autofill"));
    // fixedcolumns
    gulp.src([nodeModules + "/datatables.net-fixedcolumns/js/*.js", nodeModules + "/datatables.net-fixedcolumns-bs4/js/*.js"]).pipe(gulp.dest(libPath + "/datatables/js/fixedcolumns"));
    gulp.src(nodeModules + "/datatables.net-fixedcolumns-bs4/css/*.css").pipe(gulp.dest(libPath + "/datatables/css/fixedcolumns"));
    // fixedheader
    gulp.src([nodeModules + "/datatables.net-fixedheader/js/*.js", nodeModules + "/datatables.net-fixedheader-bs4/js/*.js"]).pipe(gulp.dest(libPath + "/datatables/js/fixedheader"));
    gulp.src(nodeModules + "/datatables.net-fixedheader-bs4/css/*.css").pipe(gulp.dest(libPath + "/datatables/css/fixedheader"));
    // keytable
    gulp.src([nodeModules + "/datatables.net-keytable/js/*.js", nodeModules + "/datatables.net-keytable-bs4/js/*.js"]).pipe(gulp.dest(libPath + "/datatables/js/keytable"));
    gulp.src(nodeModules + "/datatables.net-keytable-bs4/css/*.css").pipe(gulp.dest(libPath + "/datatables/css/keytable"));
    // responsive
    gulp.src([nodeModules + "/datatables.net-responsive/js/*.js", nodeModules + "/datatables.net-responsive-bs4/js/*.js"]).pipe(gulp.dest(libPath + "/datatables/js/responsive"));
    gulp.src(nodeModules + "/datatables.net-responsive-bs4/css/*.css").pipe(gulp.dest(libPath + "/datatables/css/responsive"));
    // rowgroup
    gulp.src([nodeModules + "/datatables.net-rowgroup/js/*.js", nodeModules + "/datatables.net-rowgroup-bs4/js/*.js"]).pipe(gulp.dest(libPath + "/datatables/js/rowgroup"));
    gulp.src(nodeModules + "/datatables.net-rowgroup-bs4/css/*.css").pipe(gulp.dest(libPath + "/datatables/css/rowgroup"));
    // rowreorder
    gulp.src([nodeModules + "/datatables.net-rowreorder/js/*.js", nodeModules + "/datatables.net-rowreorder-bs4/js/*.js"]).pipe(gulp.dest(libPath + "/datatables/js/rowreorder"));
    gulp.src(nodeModules + "/datatables.net-rowreorder-bs4/css/*.css").pipe(gulp.dest(libPath + "/datatables/css/rowreorder"));
    // scroller
    gulp.src([nodeModules + "/datatables.net-scroller/js/*.js", nodeModules + "/datatables.net-scroller-bs4/js/*.js"]).pipe(gulp.dest(libPath + "/datatables/js/scroller"));
    gulp.src(nodeModules + "/datatables.net-scroller-bs4/css/*.css").pipe(gulp.dest(libPath + "/datatables/css/scroller"));
    // select
    gulp.src([nodeModules + "/datatables.net-select/js/*.js", nodeModules + "/datatables.net-select-bs4/js/*.js"]).pipe(gulp.dest(libPath + "/datatables/js/select"));
    gulp.src(nodeModules + "/datatables.net-select-bs4/css/*.css").pipe(gulp.dest(libPath + "/datatables/css/select"));

});