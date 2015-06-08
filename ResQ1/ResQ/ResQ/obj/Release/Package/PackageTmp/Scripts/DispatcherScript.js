$(".itemOfRequest").click(function () {
    var x = $(this).attr("id");
    window.location.href = "http://localhost:55609/Dispatacher/Process/" + x;
});

window.onload = function () {
    initializeMap();
}

var map;
function initializeMap() {
    var longitude = 50.0439304;
    var latitude = 36.2080766;
    var mapCanvas = document.getElementById('map-canvas');
    var mapOptions = {
        center: new google.maps.LatLng(longitude, latitude),
        zoom: 10,
        mapTypeId: google.maps.MapTypeId.ROADMAP
    }
    map = new google.maps.Map(mapCanvas, mapOptions)
    navigator.geolocation.getCurrentPosition(addMarker);

}

function addMarker(position) {

    var myLatlng = new google.maps.LatLng(position.coords.latitude, position.coords.longitude);
    var marker = new google.maps.Marker({
        position: myLatlng,
        map: map,
        title: 'Hello World!'
    });
}