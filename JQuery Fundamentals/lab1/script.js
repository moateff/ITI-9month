$(document).ready(() => {
    (function() {
        $('.services-list').slideUp(0);
        $('.section').not('.services').css('display', 'none');
        $('.nav-item').removeClass('nav-item-active');
    })();

    let listIsOpen = false;

    $('.nav-item').each((index, item) => {
        $(item).on('click', function () {
            const target = $(this).attr('id');

            $('.nav-item').removeClass('nav-item-active');
            $(this).addClass('nav-item-active');

            // Hide all normal sections (without animation)
            $('.section').not('.services').css('display', 'none');

            if (target === 'services') {
                if (listIsOpen) {
                    $('.services-list').slideUp('slow');
                    listIsOpen = false;
                    $('.nav-item').removeClass('nav-item-active');
                } else {
                    $('.services-list').slideDown('slow');
                    listIsOpen = true;
                }
            } else {
                $('.services-list').slideUp(0);
                $('.' + target).css('display', 'block');
            }
        });
    });

    images = [
        './images/1.jpg',
        './images/2.jpg',
        './images/3.jpg',
        './images/4.jpg',
        './images/5.jpg',
        './images/6.jpg',
        './images/7.jpg',
        './images/8.jpg'
    ]
    let currentIndex = 0;

    $('.prev').click(() => {
        currentIndex = (currentIndex - 1 + images.length) % images.length;
        $('.image').attr('src', images[currentIndex]);
    });

    $('.next').click(() => {
        currentIndex = (currentIndex + 1) % images.length;
        $('.image').attr('src', images[currentIndex]);
    });

    $('.form').submit(() => {
        event.preventDefault();

        $('.complaint-text').text($('.form textarea').val());
        $('.name-text').text($('.form input[name=name]').val());
        $('.email-text').text($('.form input[name=email]').val());
        $('.phone-text').text($('.form input[name=phone]').val());

        $('.complaint').css('display', 'none');
        $('.complaint-result').css('display', 'block');
    });

    $('.complaint-result button').click(() => {
        $('.complaint').css('display', 'block');
        $('.complaint-result').css('display', 'none');
    });
});