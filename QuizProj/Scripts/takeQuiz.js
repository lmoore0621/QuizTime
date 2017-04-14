$(document).ready(function () {
    var uploadedQuiz = document.getElementById("uploadedQuiz"),
    nextQuestionBtn = document.getElementById("nextQuestionBtn"),
    currentQuestionId;

    var clickAction = function clickAction(action) {
        var answerSubmission = {
            questionId: currentQuestionId,
            answerId: action.currentTarget.id
        };

        $.getJSON("/api/QuestionApi/CorrectAnswer", answerSubmission)
        .done(function (data) {
            if (data.IsCorrect) {
                var ans
                //document.getElementById("answer-result").innerHTML = "Right: Yeah! You got it.";
                document.getElementById("answer-result").innerHTML =
                    '<div class="panel panel-primary">' +
                       '<div class="panel-heading">' +
                           'Right' +
                       '</div>' +
                       '<div class="panel-body right-answer">' +
                           'Yeah! You got it.' +
                       '</div>' +
                     '</div>';
            } else {
                document.getElementById("answer-result").innerHTML =
                    '<div class="panel panel-danger">' +
                          '<div class="panel-heading">' +
                              'Wrong' +
                          '</div>' +
                          '<div class="panel-body wrong-answer">' +
                              'Sorry, you are a loser.' +
                          '</div>' +
                        '</div>';
            }
        })
        .fail(function (jqxhr, textStatus, error) {
            alert("Whoops! Something went wrong!")
        });
    }

    nextQuestionBtn.addEventListener('click', function () {
        $.getJSON("/api/QuestionApi", function (data) {
            var questionDiv = document.createElement('div');

            uploadedQuiz.innerHTML = "";
            currentQuestionId = data.QuestionId;

            //uploadedQuiz.id = currentQuestionId;
            uploadedQuiz.appendChild(questionDiv);
            questionDiv.innerText = data.Content;

            data.Answers.forEach(function (val) {
                var answerDiv = document.createElement('div');

                answerDiv.innerText = val.Content;
                answerDiv.id = val.AnswerId;
                answerDiv.addEventListener('click', clickAction);
                uploadedQuiz.appendChild(answerDiv);
                answerDiv.className = 'answerBox';
                answerDiv.addEventListener("mouseenter", function (event) {
                    event.target.style.color = "green";
                });
                answerDiv.addEventListener("mouseout", function (event) {
                    event.target.style.color = "black";
                });


                uploadedQuiz.className = 'questionText';
            });
        });
    });
});