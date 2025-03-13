USE dbescolamu;


CREATE TABLE tbAluno (
	idAl INT PRIMARY KEY AUTO_INCREMENT,
    nomeAluno VARCHAR(100) NOT NULL,
    dataNascimento DATE NOT NULL
);



CREATE TABLE tbProfessor (
	idProf INT PRIMARY KEY AUTO_INCREMENT,
    nomeProf VARCHAR(100) NOT NULL
);

CREATE TABLE tbDisciplina (
	idDis INT PRIMARY KEY AUTO_INCREMENT,
    nomeDis VARCHAR(50) NOT NULL UNIQUE
);


CREATE TABLE tbNotas (
	idNota INT PRIMARY KEY AUTO_INCREMENT,
    idAluno INT NOT NULL,
    idDisciplina INT NOT NULL,
    idProfessor INT NOT NULL,
    nota VARCHAR(2) NOT NULL,
    FOREIGN KEY (idDisciplina) REFERENCES tbDisciplina(idDis),
    FOREIGN KEY (idAluno) REFERENCES tbAluno(idAl),
    FOREIGN KEY (idProfessor) REFERENCES tbProfessor(idProf)
);


ALTER TABLE tbAluno ADD faltas INT NOT NULL DEFAULT 0;

DESC tbAluno


