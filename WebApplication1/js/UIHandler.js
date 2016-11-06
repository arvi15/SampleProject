
function resetDataStatic(data) {


    $("#lblLocation").html("");
    $("#lblHeader").html("");
    $("#lblTime").html("");
    $("#lblWind").html("");
    $("#lblVisibility").html("");
    $("#lblSkyconditions").html("");
    $("#lblTemperature").html("");
    $("#lblPressure").html("");
    $("#lblRelativeHumidity").html("");
}
function bindDataStatic(data) {

    $("#lblLocation").html(data.Location);
    $("#lblHeader").html($('#tbCountry').val() + "-" + $('#mySelect').val());
    $("#lblTime").html(data.Time);
    $("#lblWind").html(data.Wind);
    $("#lblVisibility").html(data.Visibility);
    $("#lblSkyconditions").html(data.Skyconditions);
    $("#lblTemperature").html(data.Temperature);
    $("#lblPressure").html(data.Pressure);
    $("#lblRelativeHumidity").html(data.RelativeHumidity);
}
function bindDataDynamic(data) {
    $("#results").empty();
    $("#results").append("<div><br></div>");
    $("#results").append("<div>Location  " + data.Location + "</div>");
    $("#results").append("<div>Time  " + data.Time + "</div>");
    $("#results").append("<div>Wind  " + data.Wind + "</div>");
    $("#results").append("<div>Visibility  " + data.Visibility + "</div>");
    $("#results").append("<div>Skyconditions  " + data.Skyconditions + "</div>");
    $("#results").append("<div>Temperature  " + data.Temperature + "</div>");
    $("#results").append("<div>Pressure  " + data.Pressure + "</div>");
    $("#results").append("<div>RelativeHumidity  " + data.RelativeHumidity + "</div>");
}
function resetDropDown() {
    $('#mySelect').empty();
    $('#mySelect').append($('<option>', {
        value: 0,
        text: '--Select--'
    }));
}
function addDropdownEntries(data)
{
   
    jQuery.each(data, function (index, value) {


        $('#mySelect').append($('<option>', {
            value: value,
            text: value
        }));
    });
}
function resetUIControls() {
    resetUIMsgs();
    resetDataStatic();
    resetDropDown();
}
function resetUIMsgs() {
    $("#errorMessage").empty();
    $("#successrMessage").empty();
   
}
function writeMessage(msg,msgType)
{
    resetUIMsgs();
    switch (msgType) {
        case 'error': $("#errorMessage").append(msg);
            
            break;
       
        case 'success': $("#successrMessage").text(msg);
          break;

    }
}
function removeClass() {
    $(".temp").removeClass("success");
}
function addClass() {
    $(".temp").addClass("success");
}