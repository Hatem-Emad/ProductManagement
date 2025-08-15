import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ItemService, Item } from '../services/item.service';

interface ApiResponse {
  data?: Item[];
  items?: Item[];
  [key: string]: any;
}

@Component({
  selector: 'app-item',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './item.component.html',
  styleUrls: ['./item.component.css']
})
export class ItemComponent implements OnInit {
  items: Item[] = [];
  isLoading = false;
  errorMessage = '';
  showForm = false;
  editingItem: Item | null = null;
  formData = {
    name: '',
    description: '',
    categoryId: 1
  };

  constructor(
    private itemService: ItemService,
    private cdr: ChangeDetectorRef
  ) { }

  ngOnInit(): void {
    this.loadItems();
  }

  loadItems(): void {
    this.isLoading = true;
    this.errorMessage = '';

    this.itemService.getItems().subscribe({
      next: (response: Item[] | ApiResponse) => {
        if (Array.isArray(response)) {
          this.items = response;
        } else if (response && typeof response === 'object') {
          if (response.data && Array.isArray(response.data)) {
            this.items = response.data;
          } else if (response.items && Array.isArray(response.items)) {
            this.items = response.items;
          } else {
            const arrayProperty = this.findArrayProperty(response);
            if (arrayProperty) {
              this.items = arrayProperty;
            } else {
              this.errorMessage = 'No items found in response';
            }
          }
        } else {
          this.errorMessage = 'Invalid response format';
        }
        
        this.isLoading = false;
        this.cdr.detectChanges();
      },
      error: (error) => {
        this.errorMessage = 'Failed to load items. Please try again.';
        this.isLoading = false;
        this.cdr.detectChanges();
      }
    });
  }

  showAddForm(): void {
    this.editingItem = null;
    this.formData = { name: '', description: '', categoryId: 1 };
    this.showForm = true;
  }

  editItem(item: Item): void {
    this.editingItem = item;
    this.formData = { ...item };
    this.showForm = true;
  }

  saveItem(): void {
    if (this.editingItem) {
      const updateData = {
        id: this.editingItem.id,
        name: this.formData.name,
        description: this.formData.description,
        categoryId: this.formData.categoryId
      };
      
      this.itemService.updateItem(updateData).subscribe({
        next: (updatedItem) => {
          const index = this.items.findIndex(item => item.id === updatedItem.id);
          if (index !== -1) {
            this.items[index] = updatedItem;
          }
          this.cancelForm();
          this.cdr.detectChanges();
        },
        error: (error) => {
          this.errorMessage = 'Failed to update item. Please try again.';
        }
      });
    } else {
      this.itemService.createItem(this.formData).subscribe({
        next: (newItem) => {
          this.items.push(newItem);
          this.cancelForm();
          this.cdr.detectChanges();
        },
        error: (error) => {
          this.errorMessage = 'Failed to create item. Please try again.';
        }
      });
    }
  }

  deleteItem(id: number): void {
    if (confirm('Are you sure you want to delete this item?')) {
      this.itemService.deleteItem(id).subscribe({
        next: () => {
          this.items = this.items.filter(item => item.id !== id);
          this.cdr.detectChanges();
        },
        error: (error) => {
          this.errorMessage = 'Failed to delete item. Please try again.';
        }
      });
    }
  }

  cancelForm(): void {
    this.showForm = false;
    this.editingItem = null;
    this.formData = { name: '', description: '', categoryId: 1 };
  }

  private findArrayProperty(obj: any): any[] | null {
    for (const key in obj) {
      if (obj.hasOwnProperty(key) && Array.isArray(obj[key])) {
        return obj[key];
      }
    }
    return null;
  }
}
