CREATE TABLE igrac(
    id NVARCHAR2(6),
    ime NVARCHAR2(255) NOT NULL,
    prezime NVARCHAR2(255) NOT NULL,
    pol NVARCHAR2(1) NOT NULL,
    nadimak NVARCHAR2(255) NOT NULL,
    lozinka NVARCHAR2(255) NOT NULL,
    uzrast INTEGER NOT NULL,
    naziv_tima NVARCHAR2(255),
    id_lika NVARCHAR2(6),
    CHECK(LENGTH(id)=6)
);
CREATE UNIQUE INDEX igrac_pk ON igrac(id);
ALTER TABLE igrac ADD CONSTRAINT igrac_pk PRIMARY KEY(id) ENABLE;
CREATE SEQUENCE igrac_id_seq MINVALUE 100000 MAXVALUE 999999 INCREMENT BY 1 START WITH 100000 CACHE 20 ORDER NOCYCLE;


CREATE TABLE sesija(
    id NVARCHAR2(255),
    vreme_povezivanja DATE NOT NULL,
    duzina_sesije FLOAT NOT NULL,
    zaradjeno_zlato INTEGER NOT NULL,
    zaradjeni_xp INTEGER NOT NULL
);
CREATE UNIQUE INDEX sesija_pk ON sesija(id);
ALTER TABLE sesija ADD CONSTRAINT sesija_pk PRIMARY KEY(id) ENABLE;
CREATE SEQUENCE sesija_id_seq MINVALUE 1 MAXVALUE 999999999999999999999999999 INCREMENT BY 1 START WITH 1 CACHE 20 ORDER NOCYCLE;

CREATE TABLE lik(
    id NVARCHAR2(6),
    kolicina_zlata INTEGER NOT NULL,
    iskustvo INTEGER NOT NULL,
    stepen_zamora INTEGER NOT NULL,
    nivo_zdravlja INTEGER NOT NULL,
    tip_rase NVARCHAR2(255) NOT NULL,
    atribut_rase NVARCHAR2(255),
    tip_klase NVARCHAR2(255) NOT NULL,
    atribut_klase NVARCHAR2(255),
    CHECK(LENGTH(id)=6)
);
CREATE UNIQUE INDEX lik_pk ON lik(id);
ALTER TABLE lik ADD CONSTRAINT lik_pk PRIMARY KEY(id) ENABLE;
CREATE SEQUENCE lik_id_seq MINVALUE 100000 MAXVALUE 999999 INCREMENT BY 1 START WITH 100000 CACHE 20 ORDER NOCYCLE;
ALTER TABLE igrac ADD CONSTRAINT fk_igrac_lik FOREIGN KEY(id_lika) REFERENCES lik(id);
ALTER TABLE lik ADD CONSTRAINT lik_rasa_chk CHECK (tip_rase IN ('covek','patuljak','ork','demon','vilenjak')) ENABLE;
ALTER TABLE lik ADD CONSTRAINT lik_klasa_chk CHECK (tip_klase IN ('lopov','borac','oklopnik','carobnjak','svestenik','strelac')) ENABLE;

CREATE TABLE tim(
    naziv NVARCHAR2(255),
    plasman INTEGER NOT NULL,
    bonus_poeni INTEGER NOT NULL,
    max_igraci INTEGER NOT NULL,
    min_igraci INTEGER NOT NULL
);
CREATE UNIQUE INDEX tim_pk ON tim(naziv);
ALTER TABLE tim ADD CONSTRAINT tim_pk PRIMARY KEY(naziv) ENABLE;

CREATE TABLE predmet(
    naziv NVARCHAR2(255),
    opis NVARCHAR2(255) NOT NULL,
    nadimci_likova NVARCHAR2(255),
    bonus_iskustvo INTEGER NOT NULL,
    rase NVARCHAR2(255)
);
CREATE UNIQUE INDEX predmet_pk ON predmet(naziv);
ALTER TABLE predmet ADD CONSTRAINT predmet_pk PRIMARY KEY(naziv) ENABLE;

CREATE TABLE proizvod(
    naziv NVARCHAR2(255),
    opis NVARCHAR2(255) NOT NULL,
    klase NVARCHAR2(255),
    rase NVARCHAR2(255),
    odbrambeni_poeni NUMBER(4,1) NOT NULL,
    napadacki_poeni NUMBER(4,1) NOT NULL
);
CREATE UNIQUE INDEX proizvod_pk ON proizvod(naziv);
ALTER TABLE proizvod ADD CONSTRAINT proizvod_pk PRIMARY KEY(naziv) ENABLE;

CREATE TABLE pomocnik(
    id NVARCHAR2(9),
    ime NVARCHAR2(255) NOT NULL,
    rasa NVARCHAR2(255) NOT NULL,
    klasa NVARCHAR2(255) NOT NULL,
    bonus_zastita NUMBER(4,1) NOT NULL,
    id_igraca NVARCHAR2(6) NOT NULL,
    CHECK(LENGTH(id)=9)
);
CREATE UNIQUE INDEX pomocnik_pk ON pomocnik(id);
ALTER TABLE pomocnik ADD CONSTRAINT pomocnik_pk PRIMARY KEY(id) ENABLE;
CREATE SEQUENCE pomocnik_id_seq MINVALUE 100000000 MAXVALUE 999999999 INCREMENT BY 1 START WITH 100000000 CACHE 20 ORDER NOCYCLE;
ALTER TABLE pomocnik ADD CONSTRAINT fk_pomocnik_igrac FOREIGN KEY(id_igraca) REFERENCES igrac(id);
ALTER TABLE pomocnik ADD CONSTRAINT pomocnik_rasa_chk CHECK (rasa IN ('covek','patuljak','ork','demon','vilenjak')) ENABLE;
ALTER TABLE pomocnik ADD CONSTRAINT pomocnik_klasa_chk CHECK (klasa IN ('lopov','borac','oklopnik','carobnjak','svestenik','strelac')) ENABLE;


CREATE TABLE staza(
    naziv NVARCHAR2(255),
    bonus_poeni INTEGER NOT NULL,
    potrebne_rase NVARCHAR2(255),
    potrebne_klase NVARCHAR2(255),
    staza_za_tim NUMBER(1,0) NOT NULL
);
CREATE UNIQUE INDEX staza_pk ON staza(naziv);
ALTER TABLE staza ADD CONSTRAINT staza_pk PRIMARY KEY(naziv) ENABLE;


CREATE TABLE borba(
    id NVARCHAR2(255),
    naziv_prvog_tima NVARCHAR2(255) NOT NULL,
    naziv_drugog_tima NVARCHAR2(255) NOT NULL,
    pobednik NVARCHAR2(255) NOT NULL,
    vreme DATE NOT NULL
);
CREATE UNIQUE INDEX borba_pk ON borba(id);
ALTER TABLE borba ADD CONSTRAINT borba_pk PRIMARY KEY(id) ENABLE;
CREATE SEQUENCE borba_id_seq MINVALUE 1 MAXVALUE 999999999999999999999999999 INCREMENT BY 1 START WITH 1 CACHE 20 ORDER NOCYCLE;
ALTER TABLE borba ADD CONSTRAINT fk_borba_tim1 FOREIGN KEY(naziv_prvog_tima) REFERENCES tim(naziv);
ALTER TABLE borba ADD CONSTRAINT fk_borba_tim2 FOREIGN KEY(naziv_drugog_tima) REFERENCES tim(naziv);
ALTER TABLE borba ADD CONSTRAINT fk_pobednik FOREIGN KEY(pobednik) REFERENCES tim(naziv);

CREATE TABLE kupovina(
    id NVARCHAR2(255),
    id_igraca NVARCHAR2(6) NOT NULL,
    naziv_proizvoda NVARCHAR2(255) NOT NULL
);
CREATE UNIQUE INDEX kupovina_pk ON kupovina(id);
ALTER TABLE kupovina ADD CONSTRAINT kupovina_pk PRIMARY KEY(id) ENABLE;
CREATE SEQUENCE kupovina_id_seq MINVALUE 1 MAXVALUE 999999999999999999999999999 INCREMENT BY 1 START WITH 1 CACHE 20 ORDER NOCYCLE;
ALTER TABLE kupovina ADD CONSTRAINT fk_kupovina_igrac FOREIGN KEY(id_igraca) REFERENCES igrac(id);
ALTER TABLE kupovina ADD CONSTRAINT fk_kupovina_proizvod FOREIGN KEY(naziv_proizvoda) REFERENCES proizvod(naziv);

CREATE TABLE igrac_igra_stazu(
    id NVARCHAR2(255),
    id_igraca NVARCHAR2(6) NOT NULL,
    naziv_staze NVARCHAR2(255) NOT NULL,
    broj_igranja INTEGER NOT NULL,
    broj_savladanih_neprijatelja INTEGER NOT NULL
);
CREATE UNIQUE INDEX igrac_igra_stazu_pk ON igrac_igra_stazu(id);
ALTER TABLE igrac_igra_stazu ADD CONSTRAINT igrac_igra_stazu_pk PRIMARY KEY(id) ENABLE;
CREATE SEQUENCE igrac_igra_stazu_id_seq MINVALUE 1 MAXVALUE 999999999999999999999999999 INCREMENT BY 1 START WITH 1 CACHE 20 ORDER NOCYCLE;
ALTER TABLE igrac_igra_stazu ADD CONSTRAINT fk_igrac_igra_stazu_igrac FOREIGN KEY(id_igraca) REFERENCES igrac(id);
ALTER TABLE igrac_igra_stazu ADD CONSTRAINT fk_igrac_igra_stazu_staza FOREIGN KEY(naziv_staze) REFERENCES staza(naziv);

CREATE TABLE igrac_igra_sesiju(
    id NVARCHAR2(255) NOT NULL,
    id_igraca NVARCHAR2(6) NOT NULL,
    id_sesije NVARCHAR2(255) NOT NULL
);
CREATE UNIQUE INDEX igrac_igra_sesiju_pk ON igrac_igra_sesiju(id);
ALTER TABLE igrac_igra_sesiju ADD CONSTRAINT pk_igrac_igra_sesiju PRIMARY KEY(id) ENABLE;
CREATE SEQUENCE igrac_igra_sesiju_id_seq MINVALUE 1 MAXVALUE 999999999999999999999999999 INCREMENT BY 1 START WITH 1 CACHE 20 ORDER NOCYCLE;
ALTER TABLE igrac_igra_sesiju ADD CONSTRAINT fk_igrac_igra_sesiju_igrac FOREIGN KEY(id_igraca) REFERENCES igrac(id);
ALTER TABLE igrac_igra_sesiju ADD CONSTRAINT fk_igrac_igra_sesiju_sesija FOREIGN KEY(id_sesije) REFERENCES sesija(id);


CREATE TABLE staza_sadrzi_predmet(
    id NVARCHAR2(255),
    naziv_staze NVARCHAR2(255) NOT NULL,
    naziv_predmeta NVARCHAR2(255) NOT NULL
);
CREATE UNIQUE INDEX staza_sadrzi_predmet_pk ON staza_sadrzi_predmet(id);
ALTER TABLE staza_sadrzi_predmet ADD CONSTRAINT pk_staza_sadrzi_predmet PRIMARY KEY(naziv_staze, naziv_predmeta) ENABLE;
CREATE SEQUENCE staza_sadrzi_predmet_id_seq MINVALUE 1 MAXVALUE 999999999999999999999999999 INCREMENT BY 1 START WITH 1 CACHE 20 ORDER NOCYCLE;
ALTER TABLE staza_sadrzi_predmet ADD CONSTRAINT fk_staza_sadrzi_predmet_staza FOREIGN KEY(naziv_staze) REFERENCES staza(naziv);
ALTER TABLE staza_sadrzi_predmet ADD CONSTRAINT fk_staza_sadrzi_predmet_predme FOREIGN KEY(naziv_predmeta) REFERENCES predmet(naziv);

REM INSERTING INTO tim
SET DEFINE OFF;
INSERT INTO TIM (naziv, plasman, bonus_poeni, max_igraci, min_igraci) values ('Zmajevi', 1, 375, 5,1);
INSERT INTO TIM (naziv, plasman, bonus_poeni, max_igraci, min_igraci) values ('Plavi', 2, 249, 5,1);
INSERT INTO TIM (naziv, plasman, bonus_poeni, max_igraci, min_igraci) values ('Ratnici', 3, 174, 5,1);

REM INSERTING INTO lik
SET DEFINE OFF;
INSERT INTO lik (id, kolicina_zlata, iskustvo, stepen_zamora, nivo_zdravlja, tip_rase, tip_klase) values (100000,50,150,170,1000,'vilenjak','oklopnik');
INSERT INTO lik (id, kolicina_zlata, iskustvo, stepen_zamora, nivo_zdravlja, tip_rase, tip_klase) values (100001,60,140,173,1000,'demon','svestenik');
INSERT INTO lik (id, kolicina_zlata, iskustvo, stepen_zamora, nivo_zdravlja, tip_rase, tip_klase) values (100002,55,156,175,1000,'ork','strelac');

REM INSERTING INTO igrac
SET DEFINE OFF;
INSERT INTO igrac (id, ime, prezime, pol, nadimak, lozinka, uzrast, naziv_tima, id_lika) values (100000,'Mihajlo','Paunovic','M', 'mixa','mixa123',21,'Zmajevi', 100001);
INSERT INTO igrac (id, ime, prezime, pol, nadimak, lozinka, uzrast, naziv_tima, id_lika) values (100001,'Matija','Todosijevic','M', 'todosije','todosije123',21,'Zmajevi', 100002);

REM INSERTING INTO sesija
SET DEFINE OFF;
INSERT INTO sesija (id, vreme_povezivanja, duzina_sesije, zaradjeno_zlato, zaradjeni_xp) values (1,SYSDATE, 2000, 10, 25);

REM INSERTING INTO predmet
SET DEFINE OFF;
INSERT INTO predmet (naziv, opis, bonus_iskustvo) values ('ekskalibur', 'mac', 200);

REM INSERTING INTO proizvod
SET DEFINE OFF;
INSERT INTO proizvod (naziv, opis, odbrambeni_poeni, napadacki_poeni) values ('malj', 'rusi', 0, 0);

REM INSERTING INTO staza
SET DEFINE OFF;
INSERT INTO staza (naziv, bonus_poeni, staza_za_tim) values ('dust', 70, 0);

REM INSERTING INTO pomocnik
SET DEFINE OFF;
INSERT INTO pomocnik (id, ime, rasa, klasa, bonus_zastita, id_igraca) values (100000000, 'vila', 'vilenjak', 'carobnjak', 130, 100000);

REM INSERTING INTO igrac_igra_sesiju
SET DEFINE OFF;
INSERT INTO igrac_igra_sesiju (id, id_igraca, id_sesije) values (1, 100000, 1);

REM INSERTING INTO borba
SET DEFINE OFF;
Insert INTO borba  (id, naziv_prvog_tima, naziv_drugog_tima, pobednik, vreme) values (1, 'Zmajevi', 'Ratnici', 'Zmajevi', SYSDATE);

CREATE OR REPLACE TRIGGER igrac_auto_pk
    BEFORE INSERT
    ON igrac
    REFERENCING NEW AS NEW
    FOR EACH ROW
BEGIN
    SELECT igrac_id_seq.NEXTVAL INTO :NEW.id FROM DUAL;
END;
/
ALTER TRIGGER igrac_auto_pk ENABLE;

CREATE OR REPLACE TRIGGER lik_auto_pk
    BEFORE INSERT
    ON lik
    REFERENCING NEW AS NEW
    FOR EACH ROW
BEGIN
    SELECT lik_id_seq.NEXTVAL INTO :NEW.id FROM DUAL;
END;
/
ALTER TRIGGER lik_auto_pk ENABLE;

CREATE OR REPLACE TRIGGER pomocnik_auto_pk
    BEFORE INSERT
    ON pomocnik
    REFERENCING NEW AS NEW
    FOR EACH ROW
BEGIN
    SELECT pomocnik_id_seq.NEXTVAL INTO :NEW.id FROM DUAL;
END;
/
ALTER TRIGGER pomocnik_auto_pk ENABLE;


CREATE OR REPLACE TRIGGER borba_auto_pk
    BEFORE INSERT
    ON borba
    REFERENCING NEW AS NEW
    FOR EACH ROW
BEGIN
    SELECT borba_id_seq.NEXTVAL INTO :NEW.id FROM DUAL;
END;
/
ALTER TRIGGER borba_auto_pk ENABLE;

CREATE OR REPLACE TRIGGER igrac_igra_sesiju_pk
    BEFORE INSERT
    ON igrac_igra_sesiju
    REFERENCING NEW AS NEW
    FOR EACH ROW
BEGIN
    SELECT igrac_igra_sesiju_id_seq.NEXTVAL INTO :NEW.id FROM DUAL;
END;
/
ALTER TRIGGER igrac_igra_sesiju_pk ENABLE;


CREATE OR REPLACE TRIGGER igrac_igra_stazu_pk
    BEFORE INSERT
    ON igrac_igra_stazu
    REFERENCING NEW AS NEW
    FOR EACH ROW
BEGIN
    SELECT igrac_igra_stazu_id_seq.NEXTVAL INTO :NEW.id FROM DUAL;
END;
/
ALTER TRIGGER igrac_igra_stazu_pk ENABLE;

CREATE OR REPLACE TRIGGER kupovina_pk
    BEFORE INSERT
    ON kupovina
    REFERENCING NEW AS NEW
    FOR EACH ROW
BEGIN
    SELECT kupovina_id_seq.NEXTVAL INTO :NEW.id FROM DUAL;
END;
/
ALTER TRIGGER kupovina_pk ENABLE;

CREATE OR REPLACE TRIGGER sesija_pk
    BEFORE INSERT
    ON sesija
    REFERENCING NEW AS NEW
    FOR EACH ROW
BEGIN
    SELECT sesija_id_seq.NEXTVAL INTO :NEW.id FROM DUAL;
END;
/
ALTER TRIGGER sesija_pk ENABLE;

CREATE OR REPLACE TRIGGER staza_sadrzi_predmet_pk
    BEFORE INSERT
    ON staza_sadrzi_predmet
    REFERENCING NEW AS NEW
    FOR EACH ROW
BEGIN
    SELECT staza_sadrzi_predmet_id_seq.NEXTVAL INTO :NEW.id FROM DUAL;
END;
/
ALTER TRIGGER staza_sadrzi_predmet_pk ENABLE;


