# Net Core RabbitMQ
Merhabalar,

İlk yapılması gereken bilgisayarınıza yok ise docker kurulumunu gerçekleştirmek. 

https://www.docker.com/get-started

Sonraki aşamada kurulumunu tamamladığımız docker üzerinde rabbitmq ayağa kaldırmak. 

Bunun için yapılması gerekenleri sırası ile yazıyorum.

Makinamıza rabbitMQ image indirmek için; <br/>
<b>docker pull rabbitmq:latest</b> <br/> <br/>

İndirdiğimiz image üzerinden container ayağa kaldırmak için; <br/>
<b>docker run -d -hostname my-rabbit -name some-rabbit -p 4369:4369 -p 5671:5671 -p 5672:5672 -p 15672:15672 RABBITMQ_DEFAULT_USER=admin -e RABBITMQ_DEFAULT_PASS=123456 rabbitmq:latest</b> <br/> <br/>

Ayağa kaldırdığımız container üzerine UI plugin aktif etmek için; <br/>
<b>docker exec some-rabbit rabbitmq-plugins enable rabbitmq_management</b> <br/> <br/>
Bütün bunları sorunsuz yaptığımızda http://localhost:15672 adresinden UserName: admin Password: 123456 bilgileri ile management ekranına giriş yapabilirsiniz. Yapacağımız işlemlerin takibini Queue tab'ından izleyebiliriz.
