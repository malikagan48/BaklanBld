
var newIndex = 1;
showNews(newIndex);

//next-previous controls
$(".prev-news").click(function () {
    plusNews(-1);
});

$(".next-news").click(function () {
    plusNews(1);
});

function plusNews(n) {
    showNews(newIndex += n);
}

$(".news-1").click(function () {
    currentNews(1);
});
$(".news-2").click(function () {
    currentNews(2);
});
$(".news-3").click(function () {
    currentNews(3);
});
$(".news-4").click(function () {
    currentNews(4);
});
$(".news-5").click(function () {
    currentNews(5);
});
$(".news-6").click(function () {
    currentNews(6);
});

function currentNews(n) {
    showNews(newIndex = n);
}

function showNews(n) {
    var i;
    var news = $(".myNewsSlides");
    var dots = $(".demo");


    if (n > news.length) {
        newIndex = 1;
    }
    if (n < 1) {
        newIndex = news.length;
    }
    for (var i = 0; i < news.length; i++) {
        news[i].style.display = "none";
    }

    for (var i = 0; i < dots.length; i++) {
        //dots[i].className.replace("active", "");
        dots[i].classList.remove("active");
    }
    news[newIndex - 1].style.display = "block";
    dots[newIndex - 1].className += " active";
    $("#caption").html(dots[newIndex - 1].alt);
    setTimeout(showNews, 2000);
}