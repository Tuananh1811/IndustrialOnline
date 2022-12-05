const queryImg = document.querySelectorAll(".small-img");
const bigImg = document.getElementById('big-img');
const partnerImgSlickStyle = document.querySelectorAll(".partner-img-slick-style");
for (let i = 0; i < queryImg.length; i++) {
    const SmallImg = queryImg[i];
    SmallImg.addEventListener("click", function(e) {
        e.preventDefault();
        document.getElementById("img01").src = SmallImg.src;
        bigImg.src = SmallImg.src;
        document.getElementById("modal01").style.display = "block";
    })
}
bigImg.addEventListener("click", function(e) {
    e.preventDefault();
    document.getElementById("img01").src = bigImg.src;

    document.getElementById("modal01").style.display = "block";

})
for (let i = 0; i < partnerImgSlickStyle.length; i++) {
    const partnerImgSlickStyleItem = partnerImgSlickStyle[i];
    partnerImgSlickStyleItem.addEventListener("click", function(e) {
        e.preventDefault();
        document.getElementById("img01").src = partnerImgSlickStyleItem.src;

        document.getElementById("modal01").style.display = "block";
    })
}