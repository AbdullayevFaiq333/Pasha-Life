$(document).ready(function () {

    var languages = $('.language');

    for (var i = 0; i < languages.length; i++) {
        $(languages[i]).on('click', function (e) { 

            var id = $(this).attr('id')[0];
            var bodyLanguages = $('.language-body');
            var seoTitles = $('.seo-title'); 
           
             
            for (var i = 0; i < bodyLanguages.length; i++) {
                $(bodyLanguages[i]).hide();               
                $(seoTitles[i]).hide();               
            }

            console.log('Entered')

            $(bodyLanguages[id]).show();
            $(seoTitles[id]).show();


        });
    }

});

