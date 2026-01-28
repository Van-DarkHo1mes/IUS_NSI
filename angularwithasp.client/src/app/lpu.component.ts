import { Component, OnInit } from '@angular/core';
import { LPUService } from './lpu.service';

@Component({
  selector: 'app-lpu',
  standalone: false,
  templateUrl: './lpu.component.html',
  styleUrls: []
})
export class LPUComponent implements OnInit {

  lpulist: any[] = [];
  kslist: any[] = [];
  selectedLPU: number = 0;

  constructor(private lpuService: LPUService) { }

  ngOnInit(): void {
    this.loadLpus();
  }

  loadLpus(): void {
    this.lpuService.getLpus().subscribe(data => {
      if (data && data.length > 0) {
        this.lpulist = data;
      }
    }, error => {
      console.error('Ошибка при получении ЛПУ:', error);
    });
  }

  onLpuSelect(event: Event): void {
    const selectElement = event.target as HTMLSelectElement;
    this.selectedLPU = Number(selectElement.value);

    this.lpuService.getKsForLpu(this.selectedLPU).subscribe(data => {
      this.kslist = data;
    }, error => {
      console.error('Ошибка при получении КС:', error);
    });
  }
}
