$(document).ready(function () {
    //DataTable
    $('#articlesTable').DataTable({
        language: {
            "sDecimal": ",",
            "sEmptyTable": "Tabloda herhangi bir veri mevcut değil",
            "sInfo": "_TOTAL_ kayıttan _START_ - _END_ arasındaki kayıtlar gösteriliyor",
            "sInfoEmpty": "Kayıt yok",
            "sInfoFiltered": "(_MAX_ kayıt içerisinden bulunan)",
            "sInfoPostFix": "",
            "sInfoThousands": ".",
            "sLengthMenu": "Sayfada _MENU_ kayıt göster",
            "sLoadingRecords": "Yükleniyor...",
            "sProcessing": "İşleniyor...",
            "sSearch": "Ara:",
            "sZeroRecords": "Eşleşen kayıt bulunamadı",
            "oPaginate": {
                "sFirst": "İlk",
                "sLast": "Son",
                "sNext": "Sonraki",
                "sPrevious": "Önceki"
            },
            "oAria": {
                "sSortAscending": ": artan sütun sıralamasını aktifleştir",
                "sSortDescending": ": azalan sütun sıralamasını aktifleştir"
            },
            "select": {
                "rows": {
                    "_": "%d kayıt seçildi",
                    "0": "",
                    "1": "1 kayıt seçildi"
                }
            }
        },
        "order": [[4, "desc"]] //Tablonun 4. indeksine göre (0'dan itibaren 4) ve azalan şekilde sıralanmasını ayarladık.
        //Bu şekilde 4.indis olan Tarih alanını en yeniden en eskiye göre sıralayacaktır.
    });
    //DataTable

    //Chart.js
    const categories = [
        {
            name: 'Bilim & Teknoloji',
            viewCount: '150000'
        },
        {
            name: 'Yazılım & Programlama',
            viewCount: '120000'
        },
        {
            name: 'Seyahat & Turizm',
            viewCount: '74000'
        },
        {
            name: 'Fotoğrafçılık & Sinema',
            viewCount: '93000'
        },
        {
            name: 'Kitap & Kültür',
            viewCount: '50214'
        },
        {
            name: 'Deniyorum Abi',
            viewCount: '31313'
        }
    ];

    let viewCountContext = $('#viewCountChart');//Kanvas'ı seçtik. (Yani grafik html etiketini burada seçtik.)
    let viewCountChart = new Chart(viewCountContext,
        {
        type: 'bar',
        data: {
            labels: categories.map(category => category.name),//Foreach döngüsü,
            datasets: [{
                label: 'Okunma Sayısı',
                data: categories.map(category => category.viewCount),
                backgroundColor: ['#00ADB5', '#EEEEEE', '#EAFFD0', '#C3BEF0', '#A0E4CB'],
                hoverBorderWith: 4,
                hoverBorderColor:'black'
                }]
        },
        options: {
            plugins: {
                legend: {
                    labels: {
                        font: {
                            size: 18
                            }
                        }
                    }
                }
            }
        });
    //Chart.js
});