
$(document).ready(function(){
    $('#mySelect').change( function () {
        // alert(this.value); // or $(this).val()
        GetWeatherDetails($('#tbCountry').val(),this.value);
    });
    $('#tbCountry').change(function () {
        // alert(this.value); // or $(this).val()
       // alert(this.value);
    });

    $('#tbCountry').on('input', function (e) {
        ///call reset to reset city list and error messages
        resetUIControls();
        var country = $('#tbCountry').val();
        if (ValidateCOuntry(country)) {
            $("#tbCountry").attr("disabled", "disabled");

            GetAllCities(country);
            $("#tbCountry").removeAttr("disabled");
        }
        else {
            $("#errorMessage").text("Please enter minimum four letters");

        }
        
    });
});
