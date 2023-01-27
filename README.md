
# GenericBlog - Web Blog Project

GenericBlog - ASP.NET Core 5 MVC yapısında geliştirilmiş bir web uygulamasıdır. 

Bu proje kapsamında kullanılan teknolojiler:

- ♦ C#
- ♦ ASP.NET Core MVC 5.0
- ♦ Entity Framework Core 5
- ♦ Fluent API
- ♦ Generic Repository
- ♦ Unit of Work
- ♦ AutoMapper
- ♦ JavaScript 
- ♦ Ajax
- ♦ jQuery
- ♦ HTML5 & CSS3
- ♦ MSSQL

Bu dinamik proje kapsamında iki farklı panel bulunmaktadır; kullanıcı ve yönetici paneli. Kullanıcıların ve yöneticilerin site üzerinde yapabildikleri şu şekildedir:

### Kullanıcılar;
 - Bir makale okuyabilir ve bu makaleye yorum yapabilir. Her makalenin görüntülenme ve yorum sayısı dinamik olarak güncellenmektedir. Kullanıcı bir yorum yaptığı zaman yorum öncelikle yönetici paneline gider ve yöneticinin onayından sonra makaleye ait yorumlar sekmesinde görünür olur. Makalenin görüntülenme sayısı ise cookie yönetimiyle sağlanmaktadır. 
 ### Yöneticiler;
 - Tüm kategorileri listeler. Bir kategori ekleyebilir, var olan kategoriyi düzenleyebilir, pasif yapabilir veya tamamen silebilir.
 - Tüm makaleleri listeler. Yeni bir makale ekleyebilir, var olan makaleyi düzenleyebilir, pasif yapabilir veya tamamen silebilir.
 - Makalelere yapılan yorumları listeler. Uygun görülmesi durumunda yorumu onaylayarak kullanıcı panelinde görüntülenmesini sağlayabilir, düzenleyebilir veya silebilir.
 - Tüm admin paneline erişim hakkı bulunan kullanıcıları listeler. Yeni bir kullanıcı ekleyebilir, kullanıcı bilgilerini düzenleyebilir veya bir kullanıcıyı silebilir.
 - SuperAdmin rolündeki yönetici, diğer kullanıcılara rol atayabilir. Örneğin Article.Create rolüne sahip kullanıcılar yeni bir makale oluşturabilirken, bu role sahip olmayan kullanıcılar bu işlemi yapamazlar. SuperAdmin, diğer kullanıcıların erişimlerini kısıtlayabilecek roller atayabilme hakkına sahiptir. Site üzerindeki ayarları kontrol edebilir.
 - SuperAdmin rolüne sahip kullanıcı, yönetici panelindeki ayarları yönetebilir. "Genel Ayarlar" sekmesinden site adı(başlığını), menü üzerindeki site adı(başlığını), SEO yazar, etiket ve açıklamaları düzenleyebilir. "Hakkımızda" sayfa içerikleri sekmesinden "hakkımızda" kısmında yer alan Başlık, İçerik ve SEO yazar, etiket, açıklama bilgilerini düzenleyip güncelleyebilir. "E-Posta Ayarları" sekmesinden Gönderen Adı, E-Postası gibi bilgileri güncelleyebilir. "Makale Sayfaları İçin Widget Ayarları" sekmesinde sitenin kullanıcı panelinde, makale detay sayfasında sağ tarafta bulunan widget ayarlarını düzenleyebilir. Widget başığı, listelenecek makale sayısı, filtre türü (kategori,tarih,okunma sayısı gibi), kategori, sıralama türü(okunma veya yorum sayısı gibi), sıralama ölçütü (artan,azalan) ve bu filtreleri uygulayacak tarihin başlangıç ve bitiş aralığını, maksimum ve minimum okunma ve yorum sayıları arasında listeleme ve seçim yapmayı sağlamaktadır. 
 - Admin panelinin ana sayfasını görüntüleme yetkisine sahip olan herhangi bir kullanıcı profilindeki kişisel bilgilerini veya avatar(küçük görseli) güncelleyebilir. Şifresini değiştirebilir. 
 ### Bu projenin detaylı videosunu incelemek için:

[<img src="https://i.postimg.cc/cLjZwP2K/final.jpg" width="50%">](https://youtu.be/26r4PK7FEcA "Generic Blog")

