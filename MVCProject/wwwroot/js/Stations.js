function GetStation(name1) {
    $.ajax({
        url: `/trip/GetStation?name1=${name1}`,
        success: function (result) {
            console.log(result);
            var area = document.getElementById("Station");
            area.innerHTML = result;
        }
    });

}