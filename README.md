Uygulamamızda lokalizasyonu etkinleştirmek için Program.cs dosyasında bazı kodlar yazacağız. İlk olarak,

![image](https://github.com/AhmetYasinCeyhan/LocalizationForWebAPI/assets/123759576/f2228fee-f318-4a12-9077-636a03f2e558)

kodunu eklememiz gerekiyor.
Bu kod, ASP.NET  Core uygulamamızda lokalizasyon özelliğini etkinleştirmek için kullanılır. Bu kod, uygulamamızın farklı dillerdeki metinlere uyum sağlayabilmesi için gerekli olan lokalizasyon hizmetlerini yapılandırır ve ekler.

Daha sonra eklememiz gerek kod ise

![image](https://github.com/AhmetYasinCeyhan/LocalizationForWebAPI/assets/123759576/98758ced-c89a-49a3-939f-6d5e95334544) kodudur,

bu kod lokalizasyon ayarlarını yapılandırmak için kullanılır yani ASP.NET  Core uygulamasında hangi dillerin destekleneceğini, varsayılan dilin ne olacağını ve diğer lokalizasyon seçeneklerini belirlememize olanak tanır.

Bundan sonraki adımda, bir önceki adımda bahsetmiş olduğumuz lokalizasyon ayarlarını yapmamız gerekiyor bu noktada eklememiz gereken kodlar; 
![image](https://github.com/AhmetYasinCeyhan/LocalizationForWebAPI/assets/123759576/438f035c-2c7a-46a7-a3af-2f6f80c3897f)


şimdi adım adım bu eklediğimiz kodlar ne işe yarıyor kısaca bunu izah edelim:

1. var supportedCultures = new[] { new CultureInfo("en-US"), new CultureInfo("tr-TR") };
Bu kod, liste tipinde desteklenen kültürleri belirtir.
Örneğin, "en-US" (İngilizce, Amerika Birleşik Devletleri) ve "tr-TR" (Türkçe, Türkiye) gibi kültürler belirtilmiştir.
Burada benimsediğimiz syntax yapısı bizim için önemli bu yapıya uygun resource dosyaları oluşturacağız.

2. localizationOptions.SupportedCultures = supportedCultures;
Bu satır, desteklenen kültürleri RequestLocalizationOptions nesnesine ekler.
Bu kültürler, uygulamanızın hangi dilleri destekleyeceğini belirler.
En önemli noktası uygulamanızın hangi dilleri anlayabildiğini gösterir.

3. localizationOptions.SupportedUICultures = supportedCultures;
Bu satır, desteklenen kullanıcı arayüzü kültürlerini belirtir.
Kullanıcı arayüzü kültürleri, kullanıcı arabiriminin hangi dillerde sunulacağını belirler.
En önemli noktası uygulamanızın hangi dilleri kullanacağını gösterir.

Bir üst maddedeki ile arasındaki farkı şöyle izah edebiliriz;
Uygulamanız Türkçe, İngilizce ve Almanca dillerini anlayabiliyor. Uygulamanızın kullanıcı arayüzü Türkçe ve İngilizce olacak. Bir kullanıcı Almanca bir metin girerse, uygulama bu metni anlayabilir, ancak kullanıcı arayüzü Türkçe veya İngilizce olarak kalacaktır.
Burası bir kapsamlı ayrım ancak bilinmesinde fayda vardır.

4. localizationOptions.SetDefaultCulture("tr-TR");
Bu satır, varsayılan kültürü belirler. Varsayılan kültür, uygulamanın başlangıç kültürü olarak kullanılır ve kullanıcılar başka bir dil belirtmediğinde bu kültür kullanılır.

5. localizationOptions.ApplyCurrentCultureToResponseHeaders = true;:
Bu satır, yanıt başlıklarına mevcut kültür bilgisini uygulamanın otomatik olarak eklenmesini sağlar.
Bu, tarayıcının istekleriyle uyumlu bir şekilde uygulamanın yanıtlarının dilini belirtir.
Bir kullanıcı Türkçe konuşan bir tarayıcı kullanıyorsa, uygulamanız yanıtlarını Türkçe olarak gönderir veya İngilizce konuşan bir tarayıcı kullanıyorsa, uygulamanız yanıtlarını İngilizce olarak gönderir.

Ve artık son bir kod eklememiz gerekiyor o da tüm bu yapılandırmaları yaptıktan sonra bunu uygulamak için;

![image](https://github.com/AhmetYasinCeyhan/LocalizationForWebAPI/assets/123759576/ee4515c5-5a2e-4fc1-bf55-bee4f8ae7c4a)

 bu kod uygulamanın başlatılması sırasında lokalizasyon ayarlarını uygulamak için kullanılır.
Bu kod, üst tarafta yazdığımız tüm istekler üzerinden lokalizasyon ayarlarını etkinleştirir ve uygulamanın doğru bir şekilde farklı dillerdeki kullanıcılara yanıt vermesini sağlar.
Eklediğimiz tüm kodların son haline bakalım beraber;

![image](https://github.com/AhmetYasinCeyhan/LocalizationForWebAPI/assets/123759576/bcb4e475-658f-4118-ac39-ec3afd187efb)


satır satır ekstra hangi yapılanmalarımızı eklediğimizi izah ettik.
Şimdi sıra resource dosyasını oluşturmakta;
Öncelikli olaraktan uygulamamız içerisinde bir resource klasörü oluşturalım ve bunun altında da bir sınıf oluşturalım bu sınıfımızın ismini IStringLocalizer<> içerisinde tanımlayacağız

![image](https://github.com/AhmetYasinCeyhan/LocalizationForWebAPI/assets/123759576/a62cb4d4-e95d-48cb-a29c-39da21c4db66)


Burada dikkat etmemiz gereken hususlar şunlar;
1.) MessageResources sınıfımızı başka bir namespace altında kullanacaksak public yapmalıyız.
2.) Resource klasörüne add deyip ilk önce kullanacağımız sınıfın adını (MessageResources) ardından nokta ile program.cs de tanımladığımız tr-TR yapısını uygun şekilde yazmalıyız yoksa program bu yapıyı anlamaz ve en son olarakta .resx ile dosyayı tanımlamalıyız. => MessageResources.tr-TR.resx

Resource dosyamızın içerisinde bizi karşılayan yapı Name, Value ve Comment'tir.

![image](https://github.com/AhmetYasinCeyhan/LocalizationForWebAPI/assets/123759576/74c8fe14-7e25-4b01-9e2a-55242ea35c90)

![image](https://github.com/AhmetYasinCeyhan/LocalizationForWebAPI/assets/123759576/316cf417-2fcb-4181-adbb-2bc92a99c8e1)


Bunlar arasındaki ilişkiyi açıklamak için bir görsel ile izah edelim

![image](https://github.com/AhmetYasinCeyhan/LocalizationForWebAPI/assets/123759576/9b9079e4-5c55-4299-9075-b7e5507ab94f)



Name, her bir kaydın benzersiz bir tanımlayıcısıdır ve uygulamada bu kayda erişmek için kullanılır. Türkçe veya İngilizce gibi farklı dillerde aynı adı kullanarak, farklı içerikleri temsil edebiliriz.
Value, Name ile ilişkilendirilen kaydın içeriğini temsil eder. Yani, uygulamanın belirli bir dil veya kültürde göstereceği metin, görüntü veya diğer veriyi içerir.
Comment, genellikle kaydın ne amaçla kullanıldığını veya hangi bağlamda kullanıldığını açıklayan bir açıklamadır. Name ve Value arasındaki ilişkiyi ve kaydın amacını daha iyi anlamak için kullanılır.
Ve artık son olaraktan da bu resource dosyasını uygulamamız içerisinde kullanalım;
Bunun için Web APİ projemizde bir HelloController sınıfı oluşturalım ve bu sınıf içerisinde , IStringLocalizer'ı dependency injection ile çağırıp bu yapımızı kullanalım.

![image](https://github.com/AhmetYasinCeyhan/LocalizationForWebAPI/assets/123759576/256ec5d8-13cd-4279-9de2-264ce33ed81e)


_localizer["KEY"] buradaki KEY'i index gibi düşünelim ve .resx dosyası içerisinde verdiğimiz name değerimizi yazalım.
Son olarakta uygulamamızın çıktısını görelim;
İngilizce olaraktan;

![image](https://github.com/AhmetYasinCeyhan/LocalizationForWebAPI/assets/123759576/f42d21e6-ba3e-4a9b-adc8-330164b97f5a)

Türkçe olaraktan;

![image](https://github.com/AhmetYasinCeyhan/LocalizationForWebAPI/assets/123759576/f1e9e39d-90f5-4eb6-bf60-b20c9a77da8d)


NOT 1: Swagger kullandığımız için uzantı ile cultures değiştiremiyoruz ya da ben bilmiyorum bundan dolayı dil değişimini görmek için Program.cs içerisinde yazdığımız SetDefaultCulture değerini değiştirerekten değişiklikleri gözlemliyorum.
NOT 2 :Eğer Swager kullanırken aynı zamanda uygulamanızı Google Chrome ile ayağa kaldırırsanız default değere bakmaksızın bilgisayarınızın ve kullandığınız uygulamanın dili neyse onu baz alacaktır. Bundan kurtulmak için Microsoft Edge ile uygulamanızı ayağa kaldırabilirsiniz.
