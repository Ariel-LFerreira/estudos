USE db_estudosapi;

CREATE TABLE cliente (
	id		INT				NOT NULL AUTO_INCREMENT,    
    nome	VARCHAR(100) 	NOT NULL,
    
    PRIMARY KEY (id)
);

CREATE TABLE conta (
	id				INT			NOT NULL AUTO_INCREMENT,    
    id_Cliente		INT			NOT NULL,    
    id_TipoConta    INT 		NOT NULL,    
    dt_Criacao 		DATETIME	NOT NULL,    
    ativo 			BOOLEAN 	DEFAULT TRUE,
    
    PRIMARY KEY (id),
    
    CONSTRAINT fk_cliente_conta
        FOREIGN KEY (Id_Cliente)
        REFERENCES cliente(id)

);

CREATE TABLE transacoes (
    id 					INT				NOT NULL AUTO_INCREMENT,
    dt_Transacao 		DATETIME		NOT NULL,
    contaOriegemId  	INT				NULL,
    contaDestinoId 		INT				NULL,
    valor 				DECIMAL(18,2) 	NOT NULL,    
    tipo_transferencia 	INT 			NOT NULL,
    
    PRIMARY KEY (id),
    
    CONSTRAINT fk_transacao_conta_origem
        FOREIGN KEY (contaOriegemId)
        REFERENCES conta(id),

    CONSTRAINT fk_transacao_conta_destino
        FOREIGN KEY (contaDestinoId)
        REFERENCES conta(id)
);