CREATE TABLE public.dbtodolist_categorias (
	categoriaid uuid NOT NULL,
	descricao varchar NOT NULL,
	ativo boolean NULL DEFAULT True,
	CONSTRAINT categorias_pk PRIMARY KEY (categoriaid)
);

insert into dbtodolist_categorias (categoriaid, descricao, ativo)
values (
	'5379757e-7052-4764-9bfd-58fbe23d5799',
	'Descricao teste',
	True
)
