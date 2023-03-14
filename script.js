// Slide show effect was created with help from Jignesh Patel,
// from his website imjignesh.com
// URL: https://imjignesh.com/how-to-trigger-css-animation-on-scroll/

let sections = document.querySelectorAll("section");
let options = {
    threshold: .35
};
let callback = (entries) => {
    entries.forEach((entry) => {
        let target = entry.target;
        let pageName = target.classList.item(0);

        if (entry.intersectionRatio >= .35) {
            let headerItem = document.querySelector(`header .${pageName}`);
            headerItem.classList.add("active");
        } else {
            let headerItem = document.querySelector(`header .${pageName}`);
            if (headerItem.classList.contains("active")) {
                headerItem.classList.remove("active");
            }
        }
    });
};
let observer = new IntersectionObserver(callback, options);
sections.forEach((section) => {
    observer.observe(section);
});



// Smooth tab scroll

const tabs = document.querySelectorAll('.tab');

tabs.forEach(tab => {
    tab.addEventListener('click', event => {
        event.preventDefault();
        const targetId = tab.getAttribute('href');
        const target = document.querySelector(targetId);
        target.scrollIntoView({ behavior: 'smooth' });
    });
});

// Toggle the nav on mobile screens

const navToggle = document.querySelector('.toggle-nav');
const nav = document.querySelector('nav');
const contactButton = document.querySelector('#toggleContactTab');

navToggle.addEventListener('click', function () {
    nav.classList.toggle('active');
    contactButton.classList.toggle('on');
});