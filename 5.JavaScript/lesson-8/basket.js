let basketEl = document.querySelector('.basket');
let cartIconWrapEl = document.querySelector('.cartIconWrap');
let basketTotalEl = document.querySelector('.basketTotal');


cartIconWrapEl.addEventListener('click', () => {
    basketEl.classList.toggle('hidden');
});
