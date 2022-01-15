$(document).ready(function () {

    var languages = $('.language');

    for (var i = 0; i < languages.length; i++) {
        $(languages[i]).on('click', function (e) {

            var id = $(this).attr('id')[0];
            var bodyLanguages = $('.language-body');
            var headerBodies = $('.header-body');
            var proWorks = $('.pro-work');
            var descBoxes = $('.description-Box');
            var endDescs = $('.end-description');
            var infopr1s = $('.infopr1');



            for (var i = 0; i < bodyLanguages.length; i++) {
                $(bodyLanguages[i]).hide();
                $(headerBodies[i]).hide();
                $(proWorks[i]).hide();
                $(descBoxes[i]).hide();
                $(endDescs[i]).hide();
                $(infopr1s[i]).hide();

            }

            console.log('Entered')

            $(bodyLanguages[id]).show();
            $(headerBodies[id]).show();
            $(proWorks[id]).show();
            $(descBoxes[id]).show();
            $(endDescs[id]).show();
            $(infopr1s[id]).show();



        });
    }

});

