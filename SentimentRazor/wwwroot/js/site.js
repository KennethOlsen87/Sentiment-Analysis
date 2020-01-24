/* make a GET HTTP request with the user input to the 
OnGetAnalyzeSentiment handler.*/
function getSentiment(userInput) {
    return fetch(`Index?handler=AnalyzeSentiment&text=${userInput}`)
        .then((response) => {
            return response.text();
        })
}


/* Dynamically update the position of the marker on
 the web page as sentiment is predicted.*/
function updateMarker(markerPosition, sentiment) {
    $("#markerPosition").attr("style", `left:${markerPosition}%`);
    $("#markerValue").text(sentiment);
}

/* Get the input from the user, send it to the 
 * OnGetAnalyzeSentiment function using the getSentiment
 * function and update the marker with the updateMarker */
function updateSentiment() {

    var userInput = $("#Message").val();

    getSentiment(userInput)
        .then((sentiment) => {
            switch (sentiment) {
                case "Not Toxic":
                    updateMarker(100.0, sentiment);
                    break;
                case "Toxic":
                    updateMarker(0.0, sentiment);
                    break;
                default:
                    updateMarker(45.0, "Neutral");
            }
        });
}