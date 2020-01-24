function getSentiment(userInput) {
    return fetch(`Index?handler=AnalyzeSentiment&text=${userInput}`)
        .then((response) => {
            return response.text();
        })
}

