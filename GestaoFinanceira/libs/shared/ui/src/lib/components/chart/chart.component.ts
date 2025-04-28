
import {isPlatformBrowser } from '@angular/common';
import { ChangeDetectorRef, Component, inject, Input, OnChanges, PLATFORM_ID } from '@angular/core';
import { ChartModule } from 'primeng/chart';


@Component({
    selector: 'lib-chart',
    imports:[ChartModule],
    templateUrl: './chart.component.html',
    styleUrl: './chart.component.css'
})
export class ChartComponent implements OnChanges{
    @Input() type: "line" | "bar" | "scatter" | "bubble" | "pie" | "doughnut" | "polarArea" | "radar" = "bar"
    @Input() plugins: any[] = []
    @Input() width= ""
    @Input() height= ""
    @Input() responsive = true
    @Input() labels: string[] = []
    @Input() datasets: {
        label: string;
        data: any[];
    }[] = []
    @Input() Scale: string | undefined
    @Input() loading = false

    basicData: any;

    basicOptions: any;

    platformId = inject(PLATFORM_ID);

    constructor(
        private cd: ChangeDetectorRef,
    ){}

    ngOnChanges() {
      if(!this.loading)
        this.initChart();
    }
    
    initChart() {
       
        if (isPlatformBrowser(this.platformId)) {
            const documentStyle = getComputedStyle(document.documentElement);
            const textColor = documentStyle.getPropertyValue('--p-text-color');
            const textColorSecondary = documentStyle.getPropertyValue('--p-text-muted-color');
            const surfaceBorder = documentStyle.getPropertyValue('--p-content-border-color');

            this.basicData = {
                labels: this.labels,
                datasets: this.datasets
            };

            this.basicOptions = {
                plugins: {
                    legend: {
                        labels: {
                            color: textColor,
                        },
                    },
                },
                scales: {
                    x: {
                        ticks: {
                            color: textColorSecondary,
                        },
                        grid: {
                            color: surfaceBorder,
                        },
                    },
                    y: {
                        type: this.Scale ?? 'linear',
                        beginAtZero: true,
                        ticks: {
                            color: textColorSecondary,
                        },
                        grid: {
                            color: surfaceBorder,
                        },
                    },
                },
            };
            this.cd.markForCheck()
        }
    }
}