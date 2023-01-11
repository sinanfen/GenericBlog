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
                    const newSingleComment =
                        //        `
                        //<div class="media mb-4">
                        //    <img class="d-flex mr-3 rounded-circle" src="https://randomuser.me/api/portraits/men/64.jpg" alt="">
                        //    <div class="media-body">
                        //        <h5 class="mt-0">${commentAddAjaxModel.CommentDto.Comment.CreatedByName}</h5>
                        //        ${commentAddAjaxModel.CommentDto.Comment.Text}
                        //    </div>
                        //</div>`;
                        `<div class="card card-margin">
                <div class="col-md-12">
                    <div class="card-body pt-0 mt-2">
                        <div class="widget-49">
                            <div class="widget-49-title-wrapper">
                                <figure>
                                    <img class="d-flex mr-4 mt-4 pr-1 rounded-circle" style="max-width:100px; max-height:100px;" src="https://www.kindpng.com/picc/m/78-785975_icon-profile-bio-avatar-person-symbol-chat-icon.png" alt="my img" />
                                    <figcaption class="mt-2 pl-2">
                                        <span class="widget-49-pro-title"><small><strong>${commentAddAjaxModel.CommentDto.Comment.CreatedByName}</strong></small></span>
                                        <br />
                                        <span class="widget-49-pro-title"><small>${commentAddAjaxModel.CommentDto.Comment.CreatedDate}</small></span>
                                    </figcaption>
                                </figure>
                                <div id="profile-description" class="form-group mt-3 text show-more-height">
                                    <p> ${commentAddAjaxModel.CommentDto.Comment.Text}</p>
                                </div>
                            </div>
                        </div>
                    </div>
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