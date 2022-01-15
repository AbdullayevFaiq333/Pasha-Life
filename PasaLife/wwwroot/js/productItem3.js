$(document).ready(function () {

    var languages = $('.language');

    for (var i = 0; i < languages.length; i++) {
        $(languages[i]).on('click', function (e) {

            var id = $(this).attr('id')[0];
            var bodyLanguages = $('.language-body'); 
            var headerBodies = $('.header-body');
            var desc2s = $('.desc2');
            var secondtitles = $('.secondtitle');
            var secondDescs = $('.secondDesc');
            var thirdTitles = $('.thirdTitle');
            var thirdDescs = $('.thirdDesc');
            var prinfos = $('.prinfo');



            for (var i = 0; i < bodyLanguages.length; i++) {
                $(bodyLanguages[i]).hide();
                $(headerBodies[i]).hide();
                $(desc2s[i]).hide();
                $(secondtitles[i]).hide();
                $(secondDescs[i]).hide();
                $(thirdTitles[i]).hide();
                $(thirdDescs[i]).hide();
                $(prinfos[i]).hide();

            }

            console.log('Entered')

            $(bodyLanguages[id]).show();
            $(headerBodies[id]).show();
            $(desc2s[id]).show();
            $(secondtitles[id]).show();
            $(secondDescs[id]).show();
            $(thirdTitles[id]).show();
            $(thirdDescs[id]).show();
            $(prinfos[id]).show();



        });
    }

});

