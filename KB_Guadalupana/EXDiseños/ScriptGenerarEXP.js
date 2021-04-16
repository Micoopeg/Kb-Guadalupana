$(document).ready(function(){
  $('.fa-times').on('click', function(){  /* cuando click en la cruz */
    $('.sidebar_menu').addClass('hide_menu');
    $('.toggle-menu').addClass('opacity_one');
  });
  
  $('.toggle-menu').on('click', function(){  /* cuando click en la hamburguesa */
    $('.sidebar_menu').removeClass('hide_menu');
    $('.toggle-menu').removeClass('opacity_one');
  });
});