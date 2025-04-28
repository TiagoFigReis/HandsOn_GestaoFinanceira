import {Component, OnDestroy, OnInit } from '@angular/core';
import { RelatorioComponentFacade } from './relatorios.component.facade';
import { CommonModule } from '@angular/common';
import { ChartComponent } from '@farm/ui';

@Component({
    selector: 'lib-relatorios',
    imports:[CommonModule, ChartComponent],
    templateUrl: './relatorios.component.html',
    styleUrl: './relatorios.component.css'
})
export class RelatoriosComponent implements OnInit, OnDestroy{

    Receitaloading = false

    Despesaloading = false

    labelBar: string[] = []

    labelPieFonte: string[] = []

    labelPieCategoria: string[] = []

    datasetBar: {
        label:string;
        data:any[]
    }[] = []

    dataSetPieReceita: {
        label:string;
        data:any[]
    }[] = []

    dataSetPieDespesa: {
        label:string;
        data:any[]
    }[] = []

    constructor(
        private facade: RelatorioComponentFacade
    ){}

    ngOnInit() {
        this.facade.load();

        this.labelPieFonte = ['Renda Ativa', 'Renda Passiva', 'Renda Variável', 'Renda Extra', 'Outros']

        this.labelPieCategoria = ['Despesa Fixa', 'Despesa Variável', 'Despesa Ocasional', 'Despesa Emergencial', 'Outros']

        this.labelBar = ['Janeiro', 'Fevereiro', 'Março', 'Abril', 'Maio', 'Junho', 'Julho', 'Agosto', 'Setembro', 'Outubro', 'Novembro', 'Dezembro'] 

        this.facade.receita$.subscribe((receitas) => {
            if (!receitas) return;
      
            const valuesReceitas = receitas?.map(receita => ({
                valor: receita.valor,
                mes: new Date(receita.data).getMonth()
            }) 
            )
    
            const somatorioReceitasPorMes = Array(12).fill(0)
    
            valuesReceitas?.forEach(receita => {
                const mes = receita.mes; 
                somatorioReceitasPorMes[mes] += receita.valor;
            });

            this.datasetBar.push({
                label:"Receita",
                data: somatorioReceitasPorMes
            })

            const fontesReceitas = receitas.map(receita => ({
                valor: receita.valor,
                fonte: receita.fonte
            }) 
            )

            const fonteMap: { [key: string]: number } = {
                "Renda Ativa": 0,
                "Renda Passiva": 1,
                "Renda Variável": 2,
                "Renda Extra": 3,
                "Outros": 4,
              };
            
            const somatorioReceitasPorFonte = Array(5).fill(0)

            fontesReceitas?.forEach(receita => {
                const fonte = receita.fonte
                if(typeof fonte === 'string'){
                    const index = fonteMap[fonte]
                    somatorioReceitasPorFonte[index] += receita.valor;
                }
            });

            this.dataSetPieReceita.push({
                label:"Receita",
                data: somatorioReceitasPorFonte
            })

        });

        this.facade.despesa$.subscribe((despesas) => {
            if(!despesas) return;

            const valuesDespesas = despesas?.map(despesa => ({
                valor: despesa.valor,
                mes: new Date(despesa.data).getMonth()
            }) 
            )
    
            const somatorioDespesasPorMes = Array(12).fill(0)
    
            valuesDespesas?.forEach(despesa => {
                const mes = despesa.mes; 
                somatorioDespesasPorMes[mes] += despesa.valor;
            });

            this.datasetBar.push({
                label:"Despesa",
                data: somatorioDespesasPorMes
            })

            const categoriasDespesas = despesas.map(despesa => ({
                valor: despesa.valor,
                categoria: despesa.categoria
            }) 
            )

            const categoriaMap: { [key: string]: number } = {
                "Despesa Fixa": 0,
                "Despesa Variável": 1,
                "Despesa Ocasional": 2,
                "Despesa Emergencial": 3,
                "Outros": 4,
              };
            
            const somatorioDespesasPorCategoria = Array(5).fill(0)

            categoriasDespesas?.forEach(despesa => {
                const fonte = despesa.categoria
                if(typeof fonte === 'string'){
                    const index = categoriaMap[fonte]
                    somatorioDespesasPorCategoria[index] += despesa.valor;
                }
            });

            this.dataSetPieDespesa.push({
                label:"Despesa",
                data: somatorioDespesasPorCategoria
            })

        })
      
        this.facade.loading$.subscribe(loading => {
            this.Receitaloading = loading;
            this.Despesaloading = loading;
          });

    }

    ngOnDestroy(): void {
        this.facade.reset()
    }
}