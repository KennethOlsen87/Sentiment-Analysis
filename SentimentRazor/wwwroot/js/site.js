// make a GET HTTP request with the user input to the 
//OnGetAnalyzeSentiment handler.
function getSentiment(userInput) {
    return fetch(`Index?handler=AnalyzeSentiment&text=${userInput}`)
        .then((response) => {
            return response.text();
        })
}


// Dynamically update the position of the marker on
// the web page as sentiment is predicted.
function updateMarker(markerPosition, sentiment) {
    $("#markerPosition").attr("style", `left:${markerPosition}%`);
    $("#markerValue").text(sentiment);
}