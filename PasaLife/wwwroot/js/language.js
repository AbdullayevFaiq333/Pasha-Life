$(document).ready(function () {

    var languages = $('.language');

    for (var i = 0; i < languages.length; i++) {
        $(languages[i]).on('click', function (e) {

            var id = $(this).attr('id')[0];
            var bodyLanguages = $('.language-body');
            var headerBodies = $('.header-body');
            var thirdBodies = $('.third-body');
            var fourthBodies = $('.fourth-body');
            var seoTitles = $('.seo-title');
            var seoDescs = $('.seo-desc');

            for (var i = 0; i < bodyLanguages.length; i++) {
                $(bodyLanguages[i]).hide();
                $(headerBodies[i]).hide();
                $(thirdBodies[i]).hide();
                $(fourthBodies[i]).hide();
                $(seoTitles[i]).hide();
                $(seoDescs[i]).hide();
            }

            console.log('Entered')
            $(fourthBodies[id]).show();
            $(thirdBodies[id]).show();

            console.log(fourthBodies[id]);
            console.log(thirdBodies[id]);
            $(bodyLanguages[id]).show();
            $(headerBodies[id]).show();
            $(seoTitles[id]).show();
            $(seoDescs[id]).show();


        });
    }

});

