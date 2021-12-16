$(document).ready(function () {

    var languages = $('.language');

    for (var i = 0; i < languages.length; i++) {
        $(languages[i]).on('click', function (e) {

            var id = $(this).attr('id')[0];
            var seoTitles = $('.seo-title');
            var seoDescs = $('.seo-desc');


            for (var i = 0; i < seoTitles.length; i++) {
                $(seoTitles[i]).hide();                
            }

            for (var i = 0; i < seoDescs.length; i++) {
                $(seoDescs[i]).hide();
            }


            console.log('Entered')

            $(seoTitles[id]).show();
            $(seoDescs[id]).show();


        });
    }

});

