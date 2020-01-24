using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.ML;
using SentimentRazorML.Model;





namespace SentimentRazor.Pages
{
    public class IndexModel : PageModel
    {
        // A variable to reference the PredictionEnginePool
        private readonly PredictionEnginePool<ModelInput, ModelOutput> _predictionEnginePool;

        // Constructur - injected with the PredictionEnginePool service
        public IndexModel(PredictionEnginePool<ModelInput, ModelOutput> predictionEnginePool)
        {
            _predictionEnginePool = predictionEnginePool;
        }


        // A method handler that uses the PredictionEnginePool to make predictions from user input received from the web page
        public IActionResult OnGetAnalyzeSentiment([FromQuery] string text)
        {
            // Return Neutral sentiment if the input from the user is blank or null
            if (String.IsNullOrEmpty(text)) return Content("Neutral");

            // Given a valid input, create a new instance of ModelInput.
            var input = new ModelInput { SentimentText = text };
            //Use the PredictionEnginePool to predict sentiment.
            var prediction = _predictionEnginePool.Predict(input);
            // Convert the predicted bool value into toxic or not toxic.
            var sentiment = Convert.ToBoolean(prediction.Prediction) ? "Toxic" : "Not Toxic";

            // Return the sentiment back to the web page.
            return Content(sentiment);

        }


        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }
    }
}
