-- DROP DATABASE IF EXISTS db_concert;
-- DROP DATABASE db_concert;
CREATE DATABASE db_concert;
USE db_concert;

DROP TABLE IF EXISTS customer;
DROP TABLE IF EXISTS concert;
DROP TABLE IF EXISTS jadwal;
DROP TABLE IF EXISTS kategori_kursi;
DROP TABLE IF EXISTS transaksi;
DROP TABLE IF EXISTS queue_number;

CREATE TABLE customer(
	id_cust varchar (20) PRIMARY KEY,
    nik_cust varchar (16) NOT NULL UNIQUE,
    nama_cust varchar (255) NOT NULL,
    no_telp_cust varchar (13) NOT NULL,
    birth_date_cust date NOT NULL,
    email_cust varchar (255) NOT NULL UNIQUE,
    password_cust varchar (255) NOT NULL
);

CREATE TABLE concert (
	id_concert varchar (20) PRIMARY KEY,
    nama_concert varchar (255),
    kota_concert varchar (255),
    lokasi_concert varchar (255),
    gambar varchar(255),
    desc_concert TEXT
);

CREATE TABLE jadwal (
	id_jadwal varchar (20) PRIMARY KEY,
	id_concert varchar (20) REFERENCES Concert(id_concert),
    date_jadwal DATE,
    time_jadwal TIME
);

CREATE TABLE kategori_kursi (
	id_kategori varchar (20) PRIMARY KEY,
    nama_kategori varchar (255),
    harga double,
    maxcapacity int,
    `status` varchar (20),
    id_concert varchar(20) REFERENCES Concert(id_concert)
);


CREATE TABLE transaksi (
	id_order varchar (20) PRIMARY KEY,
    totalkursi int not null,
    jenis_pembayaran varchar(20),
    id_cust varchar (20) REFERENCES Customer(id_cust),
    id_jadwal varchar (20) REFERENCES Jadwal(id_jadwal),
    id_kategori varchar (20) REFERENCES Kategori_kursi (id_kategori)
);

CREATE TABLE queue_number (
	id_order varchar (20) REFERENCES Transaksi (id_order),
    id_kategori varchar (20) REFERENCES Kategori_kursi (id_kategori),
    nokursi varchar (20)
);



INSERT INTO customer (id_cust,nik_cust,nama_cust,no_telp_cust,birth_date_cust,email_cust, password_cust)-- bikin 20
values
('C00001', '3501020607920001', 'John Doe', '081234567890', '2000-01-01', 'johndoe@gmail.com', '482c811da5d5b4bc6d497ffa98491e38'),-- pass: password123
('C00002', '1209121401950003', 'Jane Doe', '082345678901', '1995-02-14', 'janedoe@gmail.com', '96b33694c4bb7dbd07391e0be54745fb'),-- pass: password456
('C00003', '4412122804990002', 'Bob Smith', '083456789012', '2002-06-30', 'bobsmith@gmail.com', '7d347cf0ee68174a3588f6cba31b8a67'),-- pass: password789
('C00004', '3201024501230001', 'John Smith', '081311233145', '1985-03-12', 'john.smith@gmail.com', 'bdc87b9c894da5168059e00ebffb9077'),-- pass: password1234
('C00005', '7102126709120012', 'Emily Johnson', '083490871134', '1992-09-25', ' emily.johnson@gmail.com', '9233a13ff22103fe710dd837e454d6c6'),-- pass: pswt1234
('C00006', '8305085402260033', 'Michael Davis', '081789751234', '1978-06-08', 'michael.davis@gmail.com', 'd6b0ab7f1c8ab8f514db9a6d85de160a'),-- pass: abc12345
('C00007', '6409017207120044', 'Sarah Wilson', '085677886543', '1989-12-01', 'sarah.wilson@gmail.com', 'bb77d0d3b3f239fa5db73bdf27b8d29a'),-- pass: securepass
('C00008', '9203046205120055', 'David Thompson', '081167671234', '1995-04-17', 'david.thompson@gmail.com', '0f359740bd1cda994f8b55330c86d845'),-- pass: p@ssw0rd
('C00009', '5507123107060066', 'Jessica Anderson', '087789891231', '1982-07-29', 'jessica.anderson@gmail.com', 'cef7cb15dbf9278b212f134403c2e24e'),-- pass: mypswt12
('C00010', '4508095903260077', 'Robert Martin', '087989000912', '1973-10-10', 'robert.martin@gmail.com', '9be40402f45736bcb9502225fad5ec9b'),-- pass: pass123456
('C00011', '3606014801270088', 'Jennifer Taylor', '081776549090', '1991-02-14', 'jennifer.taylor@gmail.com', '7d347cf0ee68174a3588f6cba31b8a67'),-- pass: password789
('C00012', '8807064603120099', 'Christopher Brown', '083444890912', '2002-06-30', 'christopher.brown@gmail.com', 'bdc87b9c894da5168059e00ebffb9077'),-- pass: password1234
('C00013', '6701053406280100', 'Amanda Clark', '083312348876', '1990-01-19', 'amanda.clark@gmail.com', 'cc0b044bf6d02448f2ff41b8c422be5d'),-- pass: abcdefg123
('C00014', '7209025803240111', 'Daniel Lewis', '083289006789', '2002-06-30', 'daniel.lewis@gmail.com', '9c87baa223f464954940f859bcf2e233'),-- pass: mypassword123
('C00015','5904086901100122', 'Nicole Turner', '083823445671', '1979-04-02', 'nicole.turner@gmail.com', 'c2a16cdaf9bd2102d1d1e115c6bc2e00'),-- pass: securepass123
('C00016', '4107037508120133', 'Matthew Harris', '085378901234', '1993-07-15', 'matthew.harris@gmail.com', '1fb9c14e934b825a62d15230cc0c2bd1'),-- pass: p@ssw0rd123
('C00017', '2803074207300144', 'Samantha Rodriguezh', '085289711234', '1981-10-28', 'samantha.rodriguez@gmail.com', '4ae95041d151e8997a3dde671bf8ae59'),-- pass: mypassword456
('C00018', '9405116608280155', 'William Walker', '081187933041', '1986-01-10', 'william.walker@gmail.com', 'd548102de97e35352222caa977ab5a1e'),-- pass: pass1234567
('C00019', '1202095304220166', 'Elizabeth Young', '091917178902', '1994-03-24', 'elizabeth.young@gmail.com', '2138cb5b0302e84382dd9b3677576b24'),-- pass: password@123
('C00020', '8007063601250177', 'Andrew Martinez', '087788765656', '1977-06-06', 'andrew.martinez@gmail.com', '36b62b57ff828ae9f51972f471092e3b'); -- pass: securepass@1

INSERT INTO concert (id_concert,nama_concert,kota_concert,lokasi_concert,gambar,desc_concert) 
values
('CON001','COLDPLAY','Jakarta','Gelora Bung Karno Stadion','\\image\\coldplay.jpg','Coldplay is a British rock band formed in 1996. They have released 9 studio albums and are known for hit songs such as "Yellow", "Viva La Vida", "Fix You", and "Paradise". Their music is influenced by various genres, including alternative rock, pop, and electronic. Coldplay is known for their spectacular stage performances and often combines visual and dance elements with strong musical performances.'),
('CON002','JUSTIN BEIBER','Jakarta','Gelora Bung Karno Stadion','\\image\\justinbeiber.png','Justin Bieber latest album showcases his evolution as an artist, blending pop, R&B, and personal introspection into a captivating musical journey.'),
('CON003','TAYLOR SWIFT','Jakarta','Gelora Bung Karno Stadion','\\image\\taylorswift.jpg','Taylor Swift latest album, released in 2023, showcases her evolution as an artist, seamlessly blending diverse musical styles while delivering heartfelt lyrics that resonate with listeners.'),
('CON004','ALAN WALKER','Jakarta','Gelora Bung Karno Stadion','\\image\\alanwalker.jpg','Alan Walker album, known for its captivating electronic soundscapes and infectious melodies, takes listeners on a mesmerizing musical journey.'),
('CON005','MARSHMELLO','Jakarta','Gelora Bung Karno Stadion','\\image\\marshmello.jpeg','Marshmello newest album, released in 2023, is a vibrant and energetic collection of electronic dance music tracks, featuring collaborations with an array of talented artists, guaranteed to get listeners on their feet and dancing.'),
('CON006','ADELE','Jakarta','Gelora Bung Karno Stadion','\\image\\adele.jpg','Adele highly anticipated album, released in 2023, is a breathtaking masterpiece that showcases her soulful and powerful vocals, delving into themes of heartbreak, resilience, and personal growth, solidifying her status as one of the greatest vocalists of our time.'),
('CON007','BLACK PINK','Jakarta','Gelora Bung Karno Stadion','\\image\\blackpink.jpg','Blackpink highly anticipated album showcases their signature blend of catchy pop hooks, fierce rap verses, and empowering anthems, solidifying their status as global icons of K-pop.'),
('CON008','BTS','Jakarta','Gelora Bung Karno Stadion','\\image\\bts.jpeg','BTS groundbreaking album seamlessly weaves introspective lyrics, diverse musical genres, and dynamic production, capturing the essence of their artistic evolution and solidifying their position as global superstars.'),
('CON009','MARTIN GARRIX','Jakarta','Gelora Bung Karno Stadion','\\image\\martingarrix.jpg','Martin Garrix captivating album takes listeners on a euphoric journey through pulsating electronic beats, infectious melodies, and collaborations with renowned artists, showcasing his unmatched talent as a producer and his ability to create unforgettable dancefloor anthems.'),
('CON010','ED SHEERAN','Jakarta','Gelora Bung Karno Stadion','\\image\\edsheeran.jpg','Ed Sheeran heartfelt album is a beautiful tapestry of introspective songwriting, soulful vocals, and a diverse range of musical influences, demonstrating his ability to craft deeply personal and universally relatable music.'),
('CON011','SELENA GOMEZ','Jakarta','Gelora Bung Karno Stadion','\\image\\selenagomez.jpg','Ed Sheeran and Selena Gomez collaborative album is a captivating fusion of their unique musical styles, showcasing their seamless chemistry and delivering a collection of infectious pop gems that explore themes of love, growth, and self-discovery.'),
('CON012','ARIANA GRANDE','Jakarta','Gelora Bung Karno Stadion','\\image\\arianagrande.jpg','Ariana Grande dynamic album combines her powerful vocal range with captivating production and introspective lyrics, creating an immersive musical experience that seamlessly transitions between pop, R&B, and dance-pop genres.'),
('CON013','RIHANA','Jakarta','Gelora Bung Karno Stadion','\\image\\rihana.jpg','Rihanna groundbreaking album pushes artistic boundaries with its genre-bending sound, captivating lyrics, and infectious hooks, solidifying her status as a fearless innovator in the music industry.'),
('CON014','BEYONCE','Jakarta','Gelora Bung Karno Stadion','\\image\\beyonce.png','Beyoncé visionary album is a masterful blend of empowering messages, diverse musical genres, and flawless vocal performances, showcasing her unmatched artistry and cementing her status as a cultural icon.'),
('CON015','SIA','Jakarta','Gelora Bung Karno Stadion','\\image\\sia.jpg','Sia emotionally charged album captivates listeners with its hauntingly beautiful vocals, introspective lyrics, and captivating melodies, offering a profound exploration of the human experience.'),
('CON016','HARRY STYLE','Jakarta','Gelora Bung Karno Stadion','\\image\\harrystyle.jpg','Harry Styles bold and eclectic album defies musical boundaries, effortlessly blending elements of rock, pop, and folk to create a timeless and introspective sonic journey that showcases his remarkable artistry and individuality.'),
('CON017','DEMI LOVATO','Jakarta','Gelora Bung Karno Stadion','\\image\\demilovato.png','Demi Lovato powerful album serves as a raw and vulnerable testimony, delving into personal struggles with unflinching honesty while offering messages of resilience, empowerment, and self-acceptance.'),
('CON018','JUSTIN TIMBERLAKE','Jakarta','Gelora Bung Karno Stadion','\\image\\justintimberlake.jpg','Justin Timberlake versatile album seamlessly blends R&B, pop, and soulful grooves, showcasing his impeccable vocal range, infectious melodies, and captivating songwriting, solidifying his status as a true musical chameleon.'),
('CON019','DUA LIPA','Jakarta','Gelora Bung Karno Stadion','\\image\\dualipa.jpg','Dua Lipa electrifying album is a masterclass in modern pop, delivering a collection of infectious, high-energy tracks infused with disco and dance-pop elements, cementing her status as a powerhouse vocalist and a trendsetter in the music industry.'),
('CON020','KATY PERRY','Jakarta','Gelora Bung Karno Stadion','\\image\\katyperry.jpg','Katy Perry vibrant album is a kaleidoscope of infectious pop anthems, empowering ballads, and captivating storytelling, showcasing her ability to create unapologetically catchy music that resonates with audiences worldwide.');


INSERT INTO jadwal (id_jadwal,id_concert,date_jadwal,time_jadwal) -- bikin 2/3 jadwal setiap concert
values
('JD001','CON001','2023-05-07','17:00'),
('JD021','CON001','2023-05-08','17:00'),
('JD002','CON002','2023-05-28','17:00'),
('JD003','CON003','2023-06-07','17:00'),
('JD024','CON003','2023-06-08','17:00'),

('JD004','CON004','2023-07-18','17:00'),
('JD025','CON004','2023-07-19','17:00'),
('JD005','CON005','2023-07-26','17:00'),
('JD006','CON006','2023-08-08','17:00'),
('JD026','CON006','2023-08-09','17:00'),
('JD007','CON007','2023-08-14','17:00'),
('JD022','CON007','2023-08-15','17:00'),
('JD023','CON007','2023-08-16','17:00'),
('JD008','CON008','2023-08-21','17:00'),
('JD027','CON008','2023-08-22','17:00'),
('JD028','CON008','2023-08-23','17:00'),
('JD009','CON009','2023-08-27','17:00'),
('JD010','CON010','2023-09-05','17:00'),
('JD029','CON010','2023-09-06','17:00'),
('JD011','CON011','2023-09-14','17:00'),
('JD030','CON011','2023-09-15','17:00'),
('JD012','CON012','2023-09-20','17:00'),
('JD031','CON012','2023-09-21','17:00'),
('JD013','CON013','2023-09-27','17:00'),
('JD032','CON013','2023-09-28','17:00'),
('JD033','CON013','2023-09-29','17:00'),
('JD014','CON014','2023-10-08','17:00'),
('JD015','CON015','2023-10-17','17:00'),
('JD034','CON015','2023-10-18','17:00'),
('JD016','CON016','2023-10-23','17:00'),
('JD035','CON016','2023-10-24','17:00'),
('JD017','CON017','2023-10-28','17:00'),
('JD018','CON018','2023-11-08','17:00'),
('JD019','CON019','2023-12-12','17:00'),
('JD036','CON019','2023-12-13','17:00'),
('JD020','CON020','2023-12-20','17:00');

INSERT INTO kategori_kursi (id_kategori,nama_kategori,harga,maxcapacity,`status`,id_concert)
values

('KK001','VIP',3000000,50,'standing','CON001'),
('KK002','PLATINUM',2400000,100,'standing','CON001'),
('KK003','GOLD',1800000,150,'standing','CON001'),
('KK004','SILVER',1400000,200,'seat','CON001'),
('KK005','BRONZE',1000000,300,'seat','CON001'),

('KK006','VIP','2000000','50','standing','CON002'),
('KK007','PLATINUM','1400000','100','standing','CON002'),
('KK008','GOLD','1200000','150','standing','CON002'),
('KK009','SILVER','1000000','200','seat','CON002'),
('KK010','BRONZE','800000','300','seat','CON002'),

('KK011','VIP','2500000','50','standing','CON003'),
('KK012','PLATINUM','2300000','100','standing','CON003'),
('KK013','GOLD','1800000','150','standing','CON003'),
('KK014','SILVER','1400000','200','seat','CON003'),
('KK015','BRONZE','1000000','300','seat','CON003'),

('KK016','VIP','2300000','50','standing','CON004'),
('KK017','PLATINUM','1900000','100','standing','CON004'),
('KK018','GOLD','1700000','150','standing','CON004'),
('KK019','SILVER','1400000','200','seat','CON004'),
('KK020','BRONZE','1000000','300','seat','CON004'),

('KK021','VIP','4000000','50','standing','CON005'),
('KK022','PLATINUM','3400000','100','standing','CON005'),
('KK023','GOLD','2800000','150','standing','CON005'),
('KK024','SILVER','1400000','200','seat','CON005'),
('KK025','BRONZE','1000000','300','seat','CON005'),

('KK026','VIP','3700000','50','standing','CON006'),
('KK027','PLATINUM','2700000','100','standing','CON006'),
('KK028','GOLD','2000000','150','standing','CON006'),
('KK029','SILVER','1700000','200','seat','CON006'),
('KK030','BRONZE','1300000','300','seat','CON006'),

('KK031','VIP','3000000','50','standing','CON007'),
('KK032','PLATINUM','2800000','100','standing','CON007'),
('KK033','GOLD','2000000','150','standing','CON007'),
('KK034','SILVER','1600000','200','seat','CON007'),
('KK035','BRONZE','8000000','300','seat','CON007'),

('KK036','VIP','3000000','50','standing','CON008'),
('KK037','PLATINUM','2800000','100','standing','CON008'),
('KK038','GOLD','2400000','150','standing','CON008'),
('KK039','SILVER','2000000','200','seat','CON008'),
('KK040','BRONZE','1400000','300','seat','CON008'),

('KK041','VIP','3100000','50','standing','CON009'),
('KK042','PLATINUM','2400000','100','standing','CON009'),
('KK043','GOLD','2000000','150','standing','CON009'),
('KK044','SILVER','1400000','200','seat','CON009'),
('KK045','BRONZE','1100000','300','seat','CON009'),

('KK046','VIP','5000000','50','standing','CON010'),
('KK047','PLATINUM','4400000','100','standing','CON010'),
('KK048','GOLD','3800000','150','standing','CON010'),
('KK049','SILVER','2400000','200','seat','CON010'),
('KK050','BRONZE','1600000','300','seat','CON010'),

('KK051','VIP','3000000','50','standing','CON011'),
('KK052','PLATINUM','2400000','100','standing','CON011'),
('KK053','GOLD','1800000','150','standing','CON011'),
('KK054','SILVER','1400000','200','seat','CON011'),
('KK055','BRONZE','1000000','300','seat','CON011'),

('KK056','VIP','2000000','50','standing','CON012'),
('KK057','PLATINUM','1400000','100','standing','CON012'),
('KK058','GOLD','1200000','150','standing','CON012'),
('KK059','SILVER','1000000','200','seat','CON012'),
('KK060','BRONZE','800000','300','seat','CON012'),

('KK061','VIP','2500000','50','standing','CON013'),
('KK062','PLATINUM','2300000','100','standing','CON013'),
('KK063','GOLD','1800000','150','standing','CON013'),
('KK064','SILVER','1400000','200','seat','CON013'),
('KK065','BRONZE','1000000','300','seat','CON013'),

('KK066','VIP','2300000','50','standing','CON014'),
('KK067','PLATINUM','1900000','100','standing','CON014'),
('KK068','GOLD','1700000','150','standing','CON014'),
('KK069','SILVER','1400000','200','seat','CON014'),
('KK070','BRONZE','1000000','300','seat','CON014'),

('KK071','VIP','4000000','50','standing','CON015'),
('KK072','PLATINUM','3400000','100','standing','CON015'),
('KK073','GOLD','2800000','150','standing','CON015'),
('KK074','SILVER','1400000','200','seat','CON015'),
('KK075','BRONZE','1000000','300','seat','CON015'),

('KK076','VIP','3700000','50','standing','CON016'),
('KK077','PLATINUM','2700000','100','standing','CON016'),
('KK078','GOLD','2000000','150','standing','CON016'),
('KK079','SILVER','1700000','200','seat','CON016'),
('KK080','BRONZE','1300000','300','seat','CON016'),

('KK081','VIP','3000000','50','standing','CON017'),
('KK082','PLATINUM','2800000','100','standing','CON017'),
('KK083','GOLD','2000000','150','standing','CON017'),
('KK084','SILVER','1600000','200','seat','CON017'),
('KK085','BRONZE','8000000','300','seat','CON017'),

('KK086','VIP','3000000','50','standing','CON018'),
('KK087','PLATINUM','2800000','100','standing','CON018'),
('KK088','GOLD','2400000','150','standing','CON018'),
('KK089','SILVER','2000000','200','seat','CON018'),
('KK090','BRONZE','1400000','300','seat','CON018'),

('KK091','VIP','3100000','50','standing','CON019'),
('KK092','PLATINUM','2400000','100','standing','CON019'),
('KK093','GOLD','2000000','150','standing','CON019'),
('KK094','SILVER','1400000','200','seat','CON019'),
('KK095','BRONZE','1100000','300','seat','CON019'),

('KK096','VIP','5000000','50','standing','CON020'),
('KK097','PLATINUM','4400000','100','standing','CON020'),
('KK098','GOLD','3800000','150','standing','CON020'),
('KK099','SILVER','2400000','200','seat','CON020'),
('KK100','BRONZE','1600000','300','seat','CON020');



INSERT INTO transaksi (id_order,totalkursi,jenis_pembayaran,id_cust,id_jadwal,id_kategori)
values
('TRA001','2','BCA','C00001','JD001','KK001'),--
('TRA002','1','MANDIRI','C00002','JD002','KK008'),--
('TRA003','4','AlFAMART','C00003','JD003','KK011'),--
('TRA004','1','INDOMART','C00003','JD005','KK024'),--
('TRA005','2','BCA','C00004','JD005','KK025'),--
('TRA006','3','MANDIRI','C00005','JD006','KK029'),--
('TRA007','1','AlFAMART','C00006','JD008','KK037'),--
('TRA008','2','INDOMART','C00007','JD010','KK046'),--
('TRA009','2','BCA','C00008','JD011','KK051'),--
('TRA010','1','MANDIRI','C00009','JD019','KK093'),--
('TRA011','2','BCA','C00010','JD014','KK068'),--
('TRA012','3','MANDIRI','C00011','JD021','KK004'),--
('TRA013','1','AlFAMART','C00012','JD013','KK064'),--
('TRA014','4','INDOMART','C00013','JD015','KK075'),--
('TRA015','2','BCA','C00014','JD016','KK076'),--
('TRA016','4','MANDIRI','C00015','JD017','KK081'),--
('TRA017','1','AlFAMART','C00016','JD008','KK036'),--
('TRA018','2','INDOMART','C00018','JD007','KK032'),--
('TRA019','2','BCA','C00019','JD003','KK011'),/*KEMBAR*/
('TRA020','4','MANDIRI','C00020','JD008','KK037');/*KEMBAR*/


INSERT INTO queue_number (id_order,id_kategori,nokursi)
values
('TRA001','KK001','VIP'),
('TRA001','KK001','VIP'),
('TRA002','KK008','GOLD'),
('TRA003','KK011','VIP'),
('TRA003','KK011','VIP'),
('TRA003','KK011','VIP'),
('TRA003','KK011','VIP'),
('TRA004','KK024','S-1'),
('TRA005','KK025','B-1'),
('TRA005','KK025','B-2'),
('TRA006','KK029','S-1'),
('TRA006','KK029','S-2'),
('TRA006','KK029','S-3'),
('TRA007','KK037','PLATINUM'),
('TRA008','KK046','VIP'),
('TRA008','KK046','VIP'),
('TRA009','KK051','VIP'),
('TRA009','KK051','VIP'),
('TRA010','KK093','GOLD'),
('TRA011','KK068','GOLD'),
('TRA011','KK068','GOLD'),
('TRA012','KK004','S-1'),
('TRA012','KK004','S-2'),
('TRA012','KK004','S-3'),
('TRA013','KK064','S-1'),
('TRA014','KK075','B-1'),
('TRA014','KK075','B-2'),
('TRA014','KK075','B-3'),
('TRA014','KK075','B-4'),
('TRA015','KK076','VIP'),
('TRA015','KK076','VIP'),
('TRA016','KK081','VIP'),
('TRA016','KK081','VIP'),
('TRA016','KK081','VIP'),
('TRA016','KK081','VIP'),
('TRA017','KK036','VIP'),
('TRA018','KK032','PLATINUM'),
('TRA018','KK032','PLATINUM'),
('TRA019','KK011','VIP'),
('TRA019','KK011','VIP'),
('TRA020','KK037','PLATINUM');
