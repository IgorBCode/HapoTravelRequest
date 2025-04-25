// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

//Sort button
function sortRequests(criteria, tableID, sortSection, buttonSpan) {
    const requestBody = document.getElementById(tableID);
    let rows = Array.from(requestBody.getElementsByTagName("tr"));

    rows.sort((a, b) => {
        let dateA = new Date(a.cells[2].innerText.split(" - ")[0]);
        let dateB = new Date(b.cells[2].innerText.split(" - ")[0]);
        switch (criteria) {
            case "newest":
                return dateB - dateA;
            case "oldest":
                return dateA - dateB;
        }
    });

    //clear existing rows
    requestBody.innerHTML = "";

    //append sorted rows
    rows.forEach((row) => requestBody.appendChild(row));

    document.getElementById(buttonSpan).textContent = criteria.charAt(0).toUpperCase() + criteria.slice(1);
}

document.addEventListener("DOMContentLoaded", function() {
    const sortLists = document.querySelectorAll("[id^='sortoptions-']");
    sortLists.forEach(sortList => {
        sortList.querySelectorAll("li").forEach((item) => {
            item.addEventListener("click", function () {
                const selectedValue = this.getAttribute("data-value");
                const buttonSpanId = sortList.id.replace('sortoptions-', 'selected-option-');
                document.getElementById(buttonSpanId).textContent = selectedValue;
            });
        });
    });
});
