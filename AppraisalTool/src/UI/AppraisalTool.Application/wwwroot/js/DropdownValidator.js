let dropDownsList = document.querySelectorAll("select");
dropDownsList.forEach((item) => {
    item.addEventListener('change', () => {
        if (item.value == null || item.value == undefined || item.value == "") {
            item.classList.add('dropdownRequired');
        }
        else {
            item.classList.remove('dropdownRequired');
        }
    })
})
