import { test, expect } from '@playwright/test';

test('basic test', async ({ page }) => {
  await page.goto('/');
  await page.waitForSelector('a.navbar-brand');
  await expect(page.locator('a.navbar-brand')).toContainText('Kevin Trickey');
})
