$(document).ready(function () {
    $(function () {
        $(document).on('click', '#btnSave', function (event) {
            event.preventDefault();//Butonun kendi default işlemi yok sayılır, engellenir.
            const form = $('#form-comment-add');
            const actionUrl = form.attr('action');
            const dataToSend = form.serialize();
            $.post(actionUrl, dataToSend).done(function (data) {
                const commentAddAjaxModel = jQuery.parseJSON(data);
                console.log(commentAddAjaxModel);
                const newFormBody = $('.form-card', commentAddAjaxModel.CommentAddPartial);
                const cardBody = $('.form-card');
                cardBody.replaceWith(newFormBody);
                const isValid = newFormBody.find('[name="IsValid"]').val() == 'True';
                if (isValid) {
                    const newSingleComment = `
                <div class="media mb-4">
                    <img class="d-flex mr-3 rounded-circle" src="https://randomuser.me/api/portraits/men/64.jpg" alt="">
                    <div class="media-body">
                        <h5 class="mt-0">${commentAddAjaxModel.CommentDto.Comment.CreatedByName}</h5>
                        ${commentAddAjaxModel.CommentDto.Comment.Text}
                    </div>
                </div>`;
                    const newSingleCommentObject = $(newSingleComment); //jQuery objesine dönüştürdük, efekt vermek için.
                    newSingleCommentObject.hide();
                    $('#comments').append(newSingleCommentObject); //append -> yorum comments divinin sonuna eklendi
                    newSingleCommentObject.fadeIn(2000);
                    toastr.success(`Sayın ${commentAddAjaxModel.CommentDto.Comment.CreatedByName}, yorumunuz başarıyla eklenmiştir. Bir örneği sizin
                    karşınıza gelecek fakat yorumunuz onaylandıktan sonra görünür olacaktır.`)
                    $('#btnSave').prop('disabled', true); //Yorum ekleme butonu disabled(pasif) olarak ayarlandı. Spamlere bir çözüm olarak.
                    setTimeout(function () {
                        $('#btnSave').prop('disabled', false);
                    }, 15000); //15 saniye sonra yorum ekleme butonu aktif olacak.
                } else {
                    let summaryText = "";
                    $('#validation-summary > ul > li').each(function () {
                        let text = $(this).text();
                        summaryText += `*${text}\n`;
                    });
                    toastr.warning(summaryText);
                }
            }).fail(function (error) {
                console.error(error);
            });
        });
    });
});