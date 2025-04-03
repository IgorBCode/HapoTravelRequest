// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.


//Sort button
function sortRequests(criteria, tableID, sortSection, buttonSpan) {
    const requestBody = document.getElementById(tableID);
let rows = Array.from(requestBody.getElementsByTagName('tr'));

    rows.sort((a,b) => {
    let dateA = new Date(a.cells[2].innerText.split(' - ')[0]);
let dateB = new Date(b.cells[2].innerText.split(' - ')[0]);
switch (criteria) {
            case 'newest':
return dateB - dateA;
case 'oldest':
return dateA - dateB;
        }
    });

//clear existing rows
requestBody.innerHTML = '';

    //append sorted rows
    rows.forEach(row => requestBody.appendChild(row));

//show current sort selection
const sortList = document.getElementById(sortSection);
    sortList.querySelectorAll('li').forEach(item => {
    item.addEventListener('click', function () {
        //get selected value from dropdown
        const selectedValue = this.getAttribute('data-value');

        //update button text
        document.getElementById(buttonSpan).textContent = selectedValue;
    });
});
}
