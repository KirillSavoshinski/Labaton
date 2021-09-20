import { Component, OnInit } from '@angular/core';
import { StructureService } from '../services/structure.service';

@Component({
  selector: 'app-panel',
  templateUrl: './panel.component.html',
  styleUrls: ['./panel.component.scss'],
})
export class PanelComponent implements OnInit {
  public file: string;
  public selectedFolder: string = null;

  constructor(private structureService: StructureService) {}

  ngOnInit(): void {
    this.structureService.selectedFolder.subscribe(
      (val) => (this.selectedFolder = val)
    );
  }

  onFileChange(event) {
      this.file = event.target.files[0];
  }

  public uploadJson(): void {
    if (this.structureService.selectedFolder) {
      let fd = new FormData();
      fd.append('file', this.file);
      this.selectedFolder = null;
      this.structureService.uploadJsonStructure(fd).subscribe(() => {
        this.structureService.selectedFolder.next(null);
        window.location.reload();
      });
    }
  }
}
