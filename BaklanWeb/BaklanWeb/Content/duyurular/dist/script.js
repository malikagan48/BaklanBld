let newsSliderCont = document.querySelector(".newsSlider")
        let newsSliderI = document.querySelectorAll(".newsSliderIn");
        let newsSliderItem = [...newsSliderI];
        let newsSliderD = document.querySelectorAll(".lim");
        let newsSliderDods = [...newsSliderD];
        let dodsUl = document.querySelector(".uld");
        let btnLeft = document.getElementById("left");
        let btnRight = document.getElementById("right");
        let limit = 0;

        btnLeft.addEventListener("click", prev);
        btnRight.addEventListener("click", next);
        nexts();
        function prev() {
            limit--;
            if (limit < 0) {
                limit = newsSliderItem.length - 1;
            }
            nexts();
        }
        function next() {
            limit++;
            if (limit >= newsSliderItem.length) {
                limit = 0;
            }
            nexts();
        }
        let replay = setInterval(next, 4000); //EN:If you delete this line, the auto-rotation will not occur. TR: Bu satırı silerseniz otomatik döndürme işlemi gerçekleşmez.

        dodsUl.addEventListener("mouseover", (e, index) => {
            newsSliderDods.forEach((em, ind) => {
                em.classList.remove("activeee");
            });
            e.target.classList.add("activeee")
            limit = Number(e.target.innerText - 1);
            nexts();
        });
        function nexts() {
            newsSliderItem.forEach((it, index) => {
                if (index == limit) {
                    it.classList.add("newsSliderInactiveee");
                } else {
                    it.classList.remove("newsSliderInactiveee");
                }
            });
            newsSliderDods.forEach((im, index) => {
                if (index == limit) {
                    im.classList.add("activeee");
                } else {
                    im.classList.remove("activeee");
                }

            });
        }