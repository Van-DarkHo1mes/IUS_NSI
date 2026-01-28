CREATE SCHEMA IF NOT EXISTS dbo;

CREATE TABLE IF NOT EXISTS dbo.LPU_nsi (
  kodLPU INTEGER PRIMARY KEY,
  title TEXT NOT NULL
);

INSERT INTO dbo.LPU_nsi (kodLPU, title) VALUES
(1, 'Ямбургское'),
(2, 'Ныдинское'),
(5, 'Пангодинское'),
(22, 'Комсомольское'),
(24, 'Ивдельское'),
(27, 'Карпинское'),
(29, 'Нижнетуринское');

CREATE TABLE IF NOT EXISTS dbo.KS_nsi (
    kodKS INTEGER PRIMARY KEY,
    kodLPU INTEGER NOT NULL,
    title TEXT NOT NULL,
    CONSTRAINT fk_ks_lpu
    FOREIGN KEY (kodLPU) REFERENCES dbo.LPU_nsi(kodLPU)
);

INSERT INTO dbo.KS_nsi (kodKS, kodLPU, title) VALUES
(1, 1, 'Ямбургская'),
(2, 2, 'Ныдинская'),
(4, 5, 'Хасырейская'),
(14, 5, 'Пангодинская'),
(5, 5, 'ЦДКС Пангоды'),
(23, 22, 'Узом-Юганская'),
(24, 22, 'Комсомольская КС-3'),
(25, 22, 'Новокомсомольская КС-11'),
(26, 22, 'Новокомсомольская КС-20'),
(28, 24, 'Ивдельская'),
(29, 24, 'Новоивдельская'),
(31, 27, 'Карпинская'),
(32, 29, 'Нижнетуринская'),
(33, 29, 'Лялинская');

CREATE OR REPLACE FUNCTION dbo.getKS(p_kodLPU INTEGER)
RETURNS TABLE (
  kodKS INTEGER,
  kodLPU INTEGER,
  title TEXT
)
LANGUAGE sql
AS $$
  SELECT kodKS, kodLPU, title
  FROM dbo.KS_nsi
  WHERE kodLPU = p_kodLPU
  ORDER BY kodKS;
$$;