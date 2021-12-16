var PashaLife = {

	initialized: false,


	/* ------ Initialize ------ */

	init: function () {

		if (PashaLife.initialized) return;
		PashaLife.initialized = true;



		if ($(".main_page_ads").length > 0) {
			var ads = $('.carousel').flickity({
				cellAlign: 'left',
				contain: true,
				prevNextButtons: false,
				pageDots: false,
				autoPlay: true,
			});
		}

		$(document).on('click', '.question', function (e) {
			var t = $(this);
		      li = t.closest("li");
		      answer = li.find(".answer");
		      answer_self = answer.find("p");
		    if (li.hasClass("active")) {
		      answer.css("height", 0);
		      li.removeClass("active");
		    } else {
					answer.css("height", answer_self.outerHeight());
		      li.addClass("active");
		    }
		})

		$(document).on('click', '.mobile_menu', function (e) {
			$("header").addClass("show_menu")
		})

		$(document).on('click', '.close_menu', function (e) {
			$("header").removeClass("show_menu")
		})

		$(document).on('click', '.active_lang', function (e) {
			$(this).toggleClass("active");
			$(".lang_select .select_box").toggleClass("open_select");
		})

		$(document).mouseup(function (e) {
			var container = $(".lang_select");
			if (!container.is(e.target) && container.has(e.target).length === 0) {
				$(".lang_select .select_box").removeClass("open_select");
				$(".active_lang").removeClass("active");
			}
		});

		$(document).on('click', '.about_video_self, .product_video_player', function (e) {
			$(".video_modal").fadeIn();
		})


		$(document).on('click', '.video_modal_bg, .close_video_modal', function (e) {
			$(".video_modal").fadeOut();
		})

		$(document).on('click', '.open_modal', function (e) {
			var t = $(this);
					modal = t.attr("data-modal")
					$(".modal[data-modal='"+modal+"']").fadeIn();
		})

		$(document).on('click', '.modal_bg, .close_modal_mobile', function (e) {
			$(".modal").fadeOut();
		})

		$(document).on('click', '.switcher button', function (e) {
			var t = $(this);
					tT = t.attr("data-tab")
					tSn = t.closest("ul").attr("data-switcher-name");
					t.closest("ul").find("button").removeClass("active");
					t.addClass("active")
					t.closest(".reports_item").find(".tabs_for_switcher[data-switcher-name='"+tSn+"']").find(".tab_content").removeClass("active")
					t.closest(".reports_item").find(".tabs_for_switcher[data-switcher-name='"+tSn+"']").find(".tab_content[data-tab='"+tT+"']").addClass("active")
		})


		var st = $(this).scrollTop();
		if (st > 0 && $(".relative_me").length) $("body").addClass("fixed_head");
		else $("body").removeClass("fixed_head");

		PashaLife.resize();







	},




	resize: function () {
		var wW = $(window).width();
		wH = $(window).height();
		$("html").removeClass("web_it mob_it");

		if (!/Android|webOS|iPhone|iPad|iPod|BlackBerry|IEMobile|Opera Mini/i.test(navigator.userAgent)) {
			$("html").addClass("web_it")
		} else {
			$("html").addClass("mob_it")
		}

		$(window).scroll(function (event) {
      var st = $(this).scrollTop();
      if (st > 0 && $(".relative_me").length == 0) $("body").addClass("fixed_head");
      else $("body").removeClass("fixed_head");
    });



	}

}

$(window).resize(function () {
	PashaLife.resize();
})


$(document).ready(function () {
	PashaLife.init();
});


$("head").append('<link href="style/basic.css?v='+(Math.random() + 1).toString(36).substring(7)+'" rel="stylesheet" type="text/css" />')

  $(document).on("click", ".scroll_to_e", function () {
  	var _this = $(this),
  	_this_scroll = _this.data("scroll"),
  	_anchor_top = $("*[data-anchor='"+_this_scroll+"']").offset().top;
  	$('html, body').animate({
        scrollTop: _anchor_top - 100
    }, 600);
  	return false;
  });


/* DateTimePicker begin */

$(document).ready(function () {

	if ($(".datetimepicker").length) {
	    $.fn.datepicker.language['en'] = {
	        days: ['Sunday', 'Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday', 'Saturday'],
	        daysShort: ['Sun', 'Mon', 'Tue', 'Wed', 'Thu', 'Fri', 'Sat'],
	        daysMin: ['Su', 'Mo', 'Tu', 'We', 'Th', 'Fr', 'Sa'],
	        months: ['January','February','March','April','May','June', 'July','August','September','October','November','December'],
	        monthsShort: ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec'],
	        today: 'Today',
	        clear: 'Clear',
	        dateFormat: 'mm/dd/yyyy',
	        timeFormat: 'hh:ii aa',
	        firstDay: 0
	    };

	    $('.datetimepicker').datepicker({
	        language: 'en',
	        dateFormat: 'dd / mm / yyyy'
	    });    
	}
});
  
/* DateTimePicker end */

  /* Form steps emulation begin */
  	$(document).on("click", ".form_steps a", function () {
  		var _this = $(this),
  		_this_index = _this.parent().index();
  		$(".career_sections section").removeClass("show_me").eq(_this_index).addClass("show_me");
  		$(".form_steps .step").addClass("fill")
  		_this.parent().addClass("fill").find("~ .step").removeClass("fill")
	  	return false;
  	});
  /* Form steps emulation end */



		/*$(document).on('mouseover', '.b_content', function (e) {
			var _this = $(this),
			_this_parents = _this.parents(".button_item");
			if (_this_parents.hasClass("b_1")) {
				$(".assistant_wrap").css("transform", "translate(-5px, -5px)");
			} else if (_this_parents.hasClass("b_2")) {
				$(".assistant_wrap").css("transform", "translate(5px, -5px)");
			} else {
				$(".assistant_wrap").css("transform", "translate(0, 5px)");
			}
		}).on('mouseleave', '.b_content', function (e) {
				$(".assistant_wrap").removeAttr("style")
		});*/
