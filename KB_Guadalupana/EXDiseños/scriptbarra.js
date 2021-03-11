$(document).ready(main);

let contador = 1;

function main() {
	$('.three').click(function() {
		if (contador == 1) { 
			$('nav').animate({
				left: "0"
			});
			contador = 0;
		} else {
			contador = 1;
			$('.nav').animate({
				left: '-100%'
			});
		}
	
	});

	// Mostramos y ocultamos submenus
	$('.submenu').click(function() {
		$(this).children('.children').slideToggle();	
	});
}


$(document).ready(function() {
  $('.hamburger').click(function() {
    $(this).toggleClass('is-active');
  });
});