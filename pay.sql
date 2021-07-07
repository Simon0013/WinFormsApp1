--
-- PostgreSQL database dump
--

-- Dumped from database version 10.16
-- Dumped by pg_dump version 10.16

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

--
-- Name: plpgsql; Type: EXTENSION; Schema: -; Owner: 
--

CREATE EXTENSION IF NOT EXISTS plpgsql WITH SCHEMA pg_catalog;


--
-- Name: EXTENSION plpgsql; Type: COMMENT; Schema: -; Owner: 
--

COMMENT ON EXTENSION plpgsql IS 'PL/pgSQL procedural language';


SET default_tablespace = '';

SET default_with_oids = false;

--
-- Name: buyer; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.buyer (
    b_id integer NOT NULL,
    b_name character varying(300) NOT NULL,
    b_inn character(10) NOT NULL,
    b_kpp character(9) NOT NULL,
    b_index character(6) NOT NULL,
    b_region character varying(100) NOT NULL,
    b_city character varying(50) NOT NULL,
    b_house character varying(10) NOT NULL,
    b_korpus character varying(10),
    b_flat character varying(10),
    b_phone character(12)
);


ALTER TABLE public.buyer OWNER TO postgres;

--
-- Name: buyer_b_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.buyer_b_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.buyer_b_id_seq OWNER TO postgres;

--
-- Name: buyer_b_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.buyer_b_id_seq OWNED BY public.buyer.b_id;


--
-- Name: consignee; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.consignee (
    c_id integer NOT NULL,
    c_name character varying(300) NOT NULL,
    c_inn character(10) NOT NULL,
    c_kpp character(9) NOT NULL,
    c_index character(6) NOT NULL,
    c_region character varying(100) NOT NULL,
    c_city character varying(50) NOT NULL,
    c_house character varying(10) NOT NULL,
    c_korpus character varying(10),
    c_flat character varying(10),
    c_phone character(12)
);


ALTER TABLE public.consignee OWNER TO postgres;

--
-- Name: consignee_c_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.consignee_c_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.consignee_c_id_seq OWNER TO postgres;

--
-- Name: consignee_c_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.consignee_c_id_seq OWNED BY public.consignee.c_id;


--
-- Name: items; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.items (
    itm_id integer NOT NULL,
    itm_name character varying(500) NOT NULL,
    itm_price numeric(12,2) NOT NULL
);


ALTER TABLE public.items OWNER TO postgres;

--
-- Name: items_itm_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.items_itm_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.items_itm_id_seq OWNER TO postgres;

--
-- Name: items_itm_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.items_itm_id_seq OWNED BY public.items.itm_id;


--
-- Name: payment; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.payment (
    pay_id integer NOT NULL,
    pay_date date NOT NULL,
    w_id integer NOT NULL,
    pr_id integer NOT NULL,
    sh_id integer NOT NULL,
    b_id integer NOT NULL,
    c_id integer NOT NULL
);


ALTER TABLE public.payment OWNER TO postgres;

--
-- Name: payment_pay_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.payment_pay_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.payment_pay_id_seq OWNER TO postgres;

--
-- Name: payment_pay_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.payment_pay_id_seq OWNED BY public.payment.pay_id;


--
-- Name: provider; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.provider (
    pr_id integer NOT NULL,
    pr_name character varying(300) NOT NULL,
    pr_inn character(10) NOT NULL,
    pr_kpp character(9) NOT NULL,
    pr_index character(6) NOT NULL,
    pr_region character varying(100) NOT NULL,
    pr_city character varying(50) NOT NULL,
    pr_house character varying(10) NOT NULL,
    pr_korpus character varying(10),
    pr_flat character varying(10),
    pr_phone character(12)
);


ALTER TABLE public.provider OWNER TO postgres;

--
-- Name: provider_pr_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.provider_pr_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.provider_pr_id_seq OWNER TO postgres;

--
-- Name: provider_pr_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.provider_pr_id_seq OWNED BY public.provider.pr_id;


--
-- Name: score; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.score (
    pay_id integer NOT NULL,
    itm_id integer NOT NULL
);


ALTER TABLE public.score OWNER TO postgres;

--
-- Name: shipper; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.shipper (
    sh_id integer NOT NULL,
    sh_name character varying(300) NOT NULL,
    sh_inn character(10) NOT NULL,
    sh_kpp character(9) NOT NULL,
    sh_index character(6) NOT NULL,
    sh_region character varying(100) NOT NULL,
    sh_city character varying(50) NOT NULL,
    sh_house character varying(10) NOT NULL,
    sh_korpus character varying(10),
    sh_flat character varying(10),
    sh_phone character(12)
);


ALTER TABLE public.shipper OWNER TO postgres;

--
-- Name: shipper_sh_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.shipper_sh_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.shipper_sh_id_seq OWNER TO postgres;

--
-- Name: shipper_sh_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.shipper_sh_id_seq OWNED BY public.shipper.sh_id;


--
-- Name: worker; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.worker (
    w_id integer NOT NULL,
    w_surname character varying(20) NOT NULL,
    w_name character varying(20) NOT NULL,
    w_patr character varying(20) NOT NULL,
    login character varying(15) NOT NULL,
    password character varying(15) NOT NULL
);


ALTER TABLE public.worker OWNER TO postgres;

--
-- Name: worker_w_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.worker_w_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.worker_w_id_seq OWNER TO postgres;

--
-- Name: worker_w_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.worker_w_id_seq OWNED BY public.worker.w_id;


--
-- Name: buyer b_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.buyer ALTER COLUMN b_id SET DEFAULT nextval('public.buyer_b_id_seq'::regclass);


--
-- Name: consignee c_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.consignee ALTER COLUMN c_id SET DEFAULT nextval('public.consignee_c_id_seq'::regclass);


--
-- Name: items itm_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.items ALTER COLUMN itm_id SET DEFAULT nextval('public.items_itm_id_seq'::regclass);


--
-- Name: payment pay_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.payment ALTER COLUMN pay_id SET DEFAULT nextval('public.payment_pay_id_seq'::regclass);


--
-- Name: provider pr_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.provider ALTER COLUMN pr_id SET DEFAULT nextval('public.provider_pr_id_seq'::regclass);


--
-- Name: shipper sh_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.shipper ALTER COLUMN sh_id SET DEFAULT nextval('public.shipper_sh_id_seq'::regclass);


--
-- Name: worker w_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.worker ALTER COLUMN w_id SET DEFAULT nextval('public.worker_w_id_seq'::regclass);


--
-- Data for Name: buyer; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.buyer (b_id, b_name, b_inn, b_kpp, b_index, b_region, b_city, b_house, b_korpus, b_flat, b_phone) FROM stdin;
1	ООО "Касторама Рус"	7703528301	366545056	115114	Московская область	Москва, Дербеневская наб	7	8	\N	\N
\.


--
-- Data for Name: consignee; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.consignee (c_id, c_name, c_inn, c_kpp, c_index, c_region, c_city, c_house, c_korpus, c_flat, c_phone) FROM stdin;
1	ООО "Касторама Рус"	7703528301	366545056	115114	Московская область	Москва, Дербеневская наб	7	8	\N	\N
2	ЗАО "Высшие технологии"	6162394545	616450999	344082	Ростовская область	Ростов-на-Дону, Братский пер	44	\N	242	+79198801974
\.


--
-- Data for Name: items; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.items (itm_id, itm_name, itm_price) FROM stdin;
1	Монитор Dell X54787696	25000.00
2	Клавиатура Logitech M-250	1000.00
3	Мышь компьютерная Oklick M-250	800.00
4	Смартфон Samsung Galaxy A5	20000.00
\.


--
-- Data for Name: payment; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.payment (pay_id, pay_date, w_id, pr_id, sh_id, b_id, c_id) FROM stdin;
1	2020-04-13	1	1	1	1	1
2	2020-06-11	1	1	1	1	2
\.


--
-- Data for Name: provider; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.provider (pr_id, pr_name, pr_inn, pr_kpp, pr_index, pr_region, pr_city, pr_house, pr_korpus, pr_flat, pr_phone) FROM stdin;
1	ООО "Форте Хоум ГмбХ"	6163076960	616401001	344002	Ростовская область	Ростов-на-Дону, Красноармейская ул	142	50	321	+78632687403
\.


--
-- Data for Name: score; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.score (pay_id, itm_id) FROM stdin;
1	1
1	2
2	2
2	3
\.


--
-- Data for Name: shipper; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.shipper (sh_id, sh_name, sh_inn, sh_kpp, sh_index, sh_region, sh_city, sh_house, sh_korpus, sh_flat, sh_phone) FROM stdin;
1	ООО "Форте Хоум ГмбХ"	6163076960	616401001	344002	Ростовская область	Ростов-на-Дону, Красноармейская ул	142	50	321	+78632687403
\.


--
-- Data for Name: worker; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.worker (w_id, w_surname, w_name, w_patr, login, password) FROM stdin;
1	Самойлова	Марья	Алексеевна	worker	worker
\.


--
-- Name: buyer_b_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.buyer_b_id_seq', 1, true);


--
-- Name: consignee_c_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.consignee_c_id_seq', 2, true);


--
-- Name: items_itm_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.items_itm_id_seq', 4, true);


--
-- Name: payment_pay_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.payment_pay_id_seq', 2, true);


--
-- Name: provider_pr_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.provider_pr_id_seq', 1, true);


--
-- Name: shipper_sh_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.shipper_sh_id_seq', 1, true);


--
-- Name: worker_w_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.worker_w_id_seq', 1, true);


--
-- Name: buyer buyer_pk; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.buyer
    ADD CONSTRAINT buyer_pk PRIMARY KEY (b_id);


--
-- Name: consignee consignee_pk; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.consignee
    ADD CONSTRAINT consignee_pk PRIMARY KEY (c_id);


--
-- Name: items items_pk; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.items
    ADD CONSTRAINT items_pk PRIMARY KEY (itm_id);


--
-- Name: payment payment_pk; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.payment
    ADD CONSTRAINT payment_pk PRIMARY KEY (pay_id);


--
-- Name: provider provider_pk; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.provider
    ADD CONSTRAINT provider_pk PRIMARY KEY (pr_id);


--
-- Name: score score_pk; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.score
    ADD CONSTRAINT score_pk PRIMARY KEY (pay_id, itm_id);


--
-- Name: shipper shipper_pk; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.shipper
    ADD CONSTRAINT shipper_pk PRIMARY KEY (sh_id);


--
-- Name: worker workers_pk; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.worker
    ADD CONSTRAINT workers_pk PRIMARY KEY (w_id);


--
-- Name: payment payment_buyer_fk; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.payment
    ADD CONSTRAINT payment_buyer_fk FOREIGN KEY (b_id) REFERENCES public.buyer(b_id);


--
-- Name: payment payment_consignee_fk; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.payment
    ADD CONSTRAINT payment_consignee_fk FOREIGN KEY (c_id) REFERENCES public.consignee(c_id);


--
-- Name: payment payment_provider_fk; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.payment
    ADD CONSTRAINT payment_provider_fk FOREIGN KEY (pr_id) REFERENCES public.provider(pr_id);


--
-- Name: payment payment_shipper_fk; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.payment
    ADD CONSTRAINT payment_shipper_fk FOREIGN KEY (sh_id) REFERENCES public.shipper(sh_id);


--
-- Name: payment payment_workers_fk; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.payment
    ADD CONSTRAINT payment_workers_fk FOREIGN KEY (w_id) REFERENCES public.worker(w_id);


--
-- Name: score score_items_fk; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.score
    ADD CONSTRAINT score_items_fk FOREIGN KEY (itm_id) REFERENCES public.items(itm_id);


--
-- Name: score score_payment_fk; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.score
    ADD CONSTRAINT score_payment_fk FOREIGN KEY (pay_id) REFERENCES public.payment(pay_id);


--
-- PostgreSQL database dump complete
--

