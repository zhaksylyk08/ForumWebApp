$(document).ready(function () {
    $(".addCommentContainer").find(".add-comment").click(function (e) {
        e.preventDefault();

        let url = "/comment/create";
        let formData = $(".addCommentContainer").find(".new-comment");

        $.post(url, formData.serialize()).done(function (answerFromServer) {
            if (answerFromServer)
            {
                alert("Your comment is added");
                $(".addCommentContainer").find(".new-comment").find('textarea').val('');
                $("body").load(urls.updatePage);
            }
        });

    });
});