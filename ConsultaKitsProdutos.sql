with 
limpeza_tb (nome, preco, custo, satisfacao_media)
 as (
	select 		
		pl.nome, 
		es.preco, 
		es.custo, 
		avg(pm.satisfacao) satisfacao_media  
	from Pesquisa_Mercado pm
		join Produto_Limpeza pl on pl.id = pm.id_produto_limpeza
		join Elemento_Estoque es on es.Id = pl.id_elemento_estoque
	group by pl.nome, es.preco, es.custo
 ),

alimento_tb (nome, preco, custo, data_validade) 
 as (
	select 		
		al.nome, 
		es.preco, 
		es.custo, 
		al.data_validade 
	from Alimento al 
		join Elemento_Estoque es on es.Id = al.id_elemento_estoque
	where DATEADD(DAY,5, GETDATE()) > al.data_validade
 ),

kit (nome_produto_limpeza, preco_produto_limpeza, nome_alimento, preco_alimento, preco_total, custo_total, data_validade) 
 as (
	select 
		limpeza_tb.nome, 
		limpeza_tb.preco, 
		alimento_tb.nome, 
		alimento_tb.preco, 
		limpeza_tb.preco + alimento_tb.preco as preco_total, 
		limpeza_tb.custo + alimento_tb.custo as custo_total, 
		alimento_tb.data_validade  
	from limpeza_tb
		cross join alimento_tb 
	where limpeza_tb.satisfacao_media > 70
 ),

kit_descontado (nome_produto_limpeza, nome_alimento, preco_total_descontado, custo_total, data_validade)
as (
	select 	
		kit.nome_produto_limpeza, 
		kit.nome_alimento, 
		kit.preco_total - (kit.preco_total * (15.0/100.0)) as preco_total_descontado,
		kit.custo_total,
		kit.data_validade
	from kit
)

select 
	nome_produto_limpeza, 
	nome_alimento, 
	preco_total_descontado as preco_kit, 
	custo_total, 
	preco_total_descontado - custo_total as lucro_kit,
	data_validade 
from kit_descontado
order by lucro_kit


