
function GetAllCities(country) {
    

    $.ajax({
        url: '/api/GetCitiesByCountry',
        type: 'GET',
        data: {
            countryName: country
        },
        dataType: "json",
        success: function (data) {
            
           
            if (data == "" || data == null) {
                
                removeClass();
                writeMessage("No cities returned.Please make sure that you entered a valid country","error");
                return false;
            }
            //change the appearance of the dropdown if cities are loaded
            addClass();
              writeMessage("Cities loaded successfully. Please select city to view weather details", "success");
              addDropdownEntries(data);
        },
        
            error: function () {
                resetDropDown();
              
                writeMessage("Error in communication.Please check after some time", "error");
            }
        
    });

}
function GetWeatherDetails(country,city) {

    $.ajax({
        url: '/api/GetWeatherByCity',
        type: 'GET',
        data: {
            countryName: country,
            cityName: city
        },
        dataType: "json",
        success: function (data) {
            
            if (data != null ) {
                //Populate the scree from the api result
                bindDataStatic(data);
                writeMessage("showing weather details for the city -" + city, "success"); 

            }
            else {
              
                writeMessage("No weather details for this city -" + city, "error");
                resetDataStatic();
               
            }
           
            //  bindDataDynamic(data);
        },
        error: function () {
                writeMessage("Error in communication.Please check after some time", "error");
            }
        
    });
}
