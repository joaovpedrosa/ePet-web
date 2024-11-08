const button = document.querySelector(".pop-button")
const modal = document.querySelector("dialog")
const buttonClose = document.querySelector("dialog img")
console.log(button)
console.log(modal)
console.log(buttonClose)

//Colocar popup dos
button.addEventListener('click', function () {
    modal.showModal()
})

buttonClose.addEventListener('click', function () {
    modal.close()
})

//animação no scroll
var root = document.documentElement;
root.className += ' js';

function boxTop(idBox) {
    var boxOffset = $(idBox).offset().top;
    return boxOffset;
}

$(document).ready(function () {
    var $target = $('.anime'),
        animationClass = 'anime-init',
        windowHeight = $(window).height(),
        offset = windowHeight - (windowHeight / 8);

    function animeScroll() {
        var documentTop = $(document).scrollTop();
        $target.each(function () {
            if (documentTop > boxTop(this) - offset) {
                $(this).addClass(animationClass);
            } else {
                $(this).removeClass(animationClass);
            }
        });
    }
    animeScroll();

    $(document).scroll(function () {
        animeScroll();
    });
});

