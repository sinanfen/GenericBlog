$(document).ready(function () {


    //Trumbowyg
    $('#text-editor').trumbowyg({
        lang: 'tr',
        btnsDef: {
            // Create a new dropdown
            image: {
                dropdown: ['insertImage', 'upload'],
                ico: 'insertImage'
            }
        },
        btns: [
            ['viewHTML'],
            ['undo', 'redo'], // Only supported in Blink browsers
            ['formatting'],
            ['strong', 'em', 'del'],
            ['superscript', 'subscript'],
            ['link'],
            ['image'],
            ['justifyLeft', 'justifyCenter', 'justifyRight', 'justifyFull'],
            ['unorderedList', 'orderedList'],
            ['horizontalRule'],
            ['removeformat'],
            ['fullscreen'],
            ['foreColor', 'backColor'],
            ['emoji'],
            ['fontfamily'],
            ['fontsize']
        ],
        plugins: {
            upload: {
                serverPath: 'https://imgur.com/upload',
                fileFieldName: 'image',
                headers: {
                    'Authorization': 'Client-ID xxxxxxxxxxxx'
                },
                urlPropertyName: 'data.link'
            },
            fontsize: {
                sizeList: [
                    '12px',
                    '14px',
                    '16px'
                ],
                allowCustomSize: false
            },
            resizimg: {
                minSize: 64,
                step: 16,
            }
        }
    });

    //Trumbowyg

    //Select2
    $('#categoryList').select2({
        theme: 'bootstrap4',
        placeholder: "Lütfen bir kategori seçiniz...",
        allowClear: true
    });
    //Select2


    // jQuery UI - DatePicker
    $(function () {
        $("#datepicker").datepicker({
            closeText: "kapat",
            prevText: "&#x3C;geri",
            nextText: "ileri&#x3e",
            currentText: "bugün",
            monthNames: ["Ocak", "Şubat", "Mart", "Nisan", "Mayıs", "Haziran",
                "Temmuz", "Ağustos", "Eylül", "Ekim", "Kasım", "Aralık"],
            monthNamesShort: ["Oca", "Şub", "Mar", "Nis", "May", "Haz",
                "Tem", "Ağu", "Eyl", "Eki", "Kas", "Ara"],
            dayNames: ["Pazar", "Pazartesi", "Salı", "Çarşamba", "Perşembe", "Cuma", "Cumartesi"],
            dayNamesShort: ["Pz", "Pt", "Sa", "Ça", "Pe", "Cu", "Ct"],
            dayNamesMin: ["Pz", "Pt", "Sa", "Ça", "Pe", "Cu", "Ct"],
            weekHeader: "Hf",
            dateFormat: "mm.dd.yy",
            firstDay: 1,
            isRTL: false,
            showMonthAfterYear: false,
            yearSuffix: "",
            duration: 500,
            showAnim: "fold",
            showOptions: { direction: "down" },
            minDate: -1,
            maxDate: +3
        });
    });
    // jQuery UI - DatePicker

});