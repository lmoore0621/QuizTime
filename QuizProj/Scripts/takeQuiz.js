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
                alert("Yes! Thats Correct!");
            } else {
                alert("Sorry! That is incorrect");
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
            uploadedQuiz.id = currentQuestionId;
            uploadedQuiz.appendChild(questionDiv);

            questionDiv.innerText = data.Content;
            data.Answers.forEach(function (val) {
                var answerDiv = document.createElement('div');
                answerDiv.innerText = val.Content;
                answerDiv.id = val.AnswerId;
                answerDiv.addEventListener('click', clickAction);
                uploadedQuiz.appendChild(answerDiv);
            });
        });
    });
});