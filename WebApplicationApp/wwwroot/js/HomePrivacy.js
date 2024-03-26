const x = [250, 235, 225, 657, 443];
const y = [450, 223, 145, 558, 666];
const urls = ["tets.html", "page1.html", "page2.html", "page3.html", "page4.html"];

for (let i = 0; i < x.length; i++) {
    const marker = document.createElement("a"); // Change div to anchor tag
    marker.href = urls[i]; // Set the URL for each marker
    marker.className = "marker";
    marker.style.left = x[i] + "px";
    marker.style.top = y[i] + "px";
    document.querySelector(".map-container").appendChild(marker);
}