// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

let list = document.querySelector(".picSlider .picList");
let item = document.querySelectorAll(".picSlider .picList .picItem");
let dots = document.querySelectorAll(".picSlider .dots li");
let prev = document.getElementById(".prev");
let next = document.getElementById(".next");

let active = 0;
let lengthItem = item.length - 1;

next.onclick = function () {
    if (active + 1 > lengthItem) {
        active = 0;
    } else {
        active = active + 1;
    }
    reloadSlider();
}

prev.onclick = function () {
    if (active - 1 < 0) {
        active = lengthItem;
    } else {
        active = active - 1;
    }
    reloadSlider();
}

let refreshSlider = setInterval(() => {
    next.click();
}, 3000);

function reloadSlider() {
    let checkLeft = item[active].offsetLeft;
    list.style.left = -checkLeft + 'px';

    let lastActiveDot = document.querySelector(".picSlider .dots li.active");
    if (lastActiveDot) {
        lastActiveDot.classList.remove('active');
    }
    dots[active].classList.add('active');

    clearInterval(refreshSlider);
    refreshSlider = setInterval(() => {
        next.click();
    }, 3000);
}

dots.forEach((li, key) => {
    li.addEventListener('click', function () {
        active = key;
        reloadSlider();
    });
});