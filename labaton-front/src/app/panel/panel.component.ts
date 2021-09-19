import { Component, OnInit } from '@angular/core';
import {
  NgxFileDropEntry,
  FileSystemFileEntry,
  FileSystemDirectoryEntry,
} from 'ngx-file-drop';
import { StructureService } from '../services/structure.service';

@Component({
  selector: 'app-panel',
  templateUrl: './panel.component.html',
  styleUrls: ['./panel.component.scss'],
})
export class PanelComponent implements OnInit {
  public file: File;
  public selectedFolder: string = null;

  constructor(private structureService: StructureService) {}

  ngOnInit(): void {
    this.structureService.selectedFolder.subscribe(val => this.selectedFolder = val);
  }

  public dropped(files: File): void {
    if (files[0].relativePath.slice(-5) === '.json') {
      this.file = files[0];
    }
  }

  public uploadJson(): void {
    if (this.structureService.selectedFolder){
      this.structureService.uploadJsonStructure(this.file).subscribe(() => {
        this.structureService.selectedFolder.next(null);
        this.selectedFolder = null;
      });
    }
    
  }
}
